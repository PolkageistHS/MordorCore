using System.Collections;
using System.Diagnostics;
using System.Reflection;
using MordorCore.Models;
using MordorCore.Models.Attributes;
using MordorCore.Models.DataFiles;

namespace MordorCore.DAL;

public class ReflectionRecordReader
{
    private readonly string _folder;
    private readonly Dictionary<Type, Action<object, DataFileReader, PropertyInfo>> _typeSetters = new();
    private readonly Dictionary<Type, Func<DataFileReader, object>> _primitiveSetters = new();

    public ReflectionRecordReader(string folder)
    {
        _folder = folder;
        Assembly.GetAssembly(typeof(DATA01GameData));
        PopulateTypeSetters();
        PopulatePrimitiveTypeSetters();
    }

    public T GetMordorRecord<T>() where T : class, IMordorDataFile
    {
        Assembly.GetAssembly(typeof(T));
        return (T)CreateClassObject(typeof(T));
    }

    private IMordorDataFile CreateClassObject(Type dataClass)
    {
        int dataRecordLength = dataClass.GetCustomAttribute<DataRecordLengthAttribute>()!.Length!.Value;
        int dataFileNum = int.Parse(dataClass.Name.Substring(4, 2));
        string filePath = Path.Combine(_folder, $"MDATA{dataFileNum}.MDR");
        DataFileReader reader = dataRecordLength == -1 ? 
            new DataFileReader(filePath) : 
            new DataFileReader(filePath, dataRecordLength);
        object instance = Activator.CreateInstance(dataClass)!;
        GetByReflection(dataClass, instance, reader);
        return (IMordorDataFile)instance;
    }

    private void GetByReflection(Type dataClass, object instance, DataFileReader reader, bool autoRead = true)
    {
        PropertyInfo[] prop = dataClass.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo propertyInfo in prop.Where(info => info.GetCustomAttribute<SkipRecordAttribute>() == null))
        {
            NewRecordAttribute? newRecord = propertyInfo.GetCustomAttribute<NewRecordAttribute>();
            Type propType = propertyInfo.PropertyType;
            if (autoRead && newRecord != null && !propType.IsArray)
                reader.Read();
            if (_typeSetters.TryGetValue(propType, out Action<object, DataFileReader, PropertyInfo>? setters))
                setters.Invoke(instance, reader, propertyInfo);
            else if (propType.IsArray)
            {
                Array array = (Array?)propertyInfo.GetValue(instance) ?? throw new Exception();
                Type elementType = propType.GetElementType()!;
                for (int i = 0; i < array.Length; i++)
                {
                    if (newRecord != null)
                        reader.Read();
                    object subInstance = Activator.CreateInstance(elementType)!;
                    if (_primitiveSetters.TryGetValue(subInstance.GetType(), out Func<DataFileReader, object>? subSetters))
                        subInstance = subSetters.Invoke(reader);
                    else
                        GetByReflection(elementType, subInstance, reader);
                    array.SetValue(subInstance, i);
                }
                propertyInfo.SetValue(instance, array);
            }
            else if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type listType = propType.GetGenericArguments()[0];
                Type genericListType = typeof(List<>).MakeGenericType(listType);
                object listInstance = Activator.CreateInstance(genericListType)!;
                MethodInfo addMethod = genericListType.GetMethod(nameof(IList.Add))!;
                while (reader.Read())
                {
                    object subInstance = Activator.CreateInstance(listType)!;
                    GetByReflection(listType, subInstance, reader, false);
                    addMethod.Invoke(listInstance, new[] { subInstance });
                }
                propertyInfo.SetValue(instance, listInstance);
            }
            else
            {
                object subInstance = Activator.CreateInstance(propType)!;
                GetByReflection(propType, subInstance, reader);
                propertyInfo.SetValue(instance, subInstance);
            }
        }
    }
    
    [DebuggerStepThrough]
    private void PopulateTypeSetters()
    {
        _typeSetters[typeof(short)] = (obj, reader, propInfo) => propInfo.SetValue(obj, reader.GetShort());
        _typeSetters[typeof(int)] = (obj, reader, propInfo) => propInfo.SetValue(obj, reader.GetInt());
        _typeSetters[typeof(long)] = (obj, reader, propInfo) => propInfo.SetValue(obj, reader.GetIntCurrency());
        _typeSetters[typeof(float)] = (obj, reader, propInfo) => propInfo.SetValue(obj, reader.GetFloat());
        _typeSetters[typeof(string)] = (obj, reader, propInfo) =>
        {
            FixedLengthStringAttribute? attr = propInfo.GetCustomAttribute<FixedLengthStringAttribute>();
            propInfo.SetValue(obj, attr == null ? reader.GetString() : reader.GetString(attr.Length));
        };
    }

    [DebuggerStepThrough]
    private void PopulatePrimitiveTypeSetters()
    {
        _primitiveSetters[typeof(short)] = reader => reader.GetShort();
        _primitiveSetters[typeof(int)] = reader => reader.GetInt();
        _primitiveSetters[typeof(long)] = reader => reader.GetIntCurrency();
        _primitiveSetters[typeof(float)] = reader => reader.GetFloat();
    }
}
