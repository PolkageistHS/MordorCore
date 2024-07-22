using System.Diagnostics;
using System.Text;

namespace MordorReader;

public sealed class RecordReader : IDisposable
{
    private readonly int _bufferLength;
    private readonly byte[] _buffer;
    private readonly FileStream _file;
    private long _cursor;

    public RecordReader(string filename)
    {
        _file = new FileStream(filename, FileMode.Open);
        _bufferLength = Convert.ToInt32(_file.Length);
        _buffer = new byte[_bufferLength];
    }

    public RecordReader(string filename, int bufferLength)
    {
        _bufferLength = bufferLength;
        _buffer = new byte[bufferLength];
        _file = new FileStream(filename, FileMode.Open);
        if (_file == null)
        {
            throw new Exception("Unable to open file!");
        }
    }

    private void CheckLength(int length)
    {
        Debug.Assert(_cursor + length <= _bufferLength);
    }

    public bool Read()
    {
        _cursor = 0;
        if (_bufferLength == 0)
        {
            return false;
        }
        return _file.Read(_buffer, 0, _bufferLength) > 0;
    }

    public void Seek(long recnum)
    {
        if (_bufferLength == 0)
        {
            _file.Seek(recnum, SeekOrigin.Begin);
        }
        else
        {
            _file.Seek((recnum - 1)* _bufferLength, SeekOrigin.Begin);
        }
    }

    private uint GetUint()
    {
        CheckLength(4);
        uint var = 0;
        for (int i = 0; i < 4; i++)
        {
            var = (var << 8) + _buffer[_cursor + 3 - i];
        }
        _cursor += 4;
        return var;
    }

    public short? GetShortIfItExists()
    {
        if (_cursor + 2 > _bufferLength)
        {
            return null;
        }
        return GetShort();
    }

    public short GetShort()
    {
        CheckLength(2);
        ushort var = (ushort)(_buffer[_cursor] + (_buffer[_cursor + 1] << 8));
        _cursor += 2;
        return (short)var;
    }

    public int GetInt() => (int)GetUint();

    private long GetLong()
    {
        ulong u = 0;
        CheckLength(8);
        for (int i = 0; i < 8; i++)
        {
            u = (u << 8) + _buffer[_cursor + 7 - i];
        }
        _cursor += 8;
        return (long)u;
    }

    public float GetFloat()
    {
        uint u = GetUint();
        byte[] bytes = BitConverter.GetBytes(u);
        return BitConverter.ToSingle(bytes, 0);
    }

    public string GetString(ushort length = 0)
    {
        if (length == 0)
        {
            length = (ushort)GetShort();
        }
        CheckLength(length);
        string str = Encoding.UTF8.GetString(_buffer, (int)_cursor, length);
        _cursor += length;
        return str;
    }

    public long GetIntCurrency() => GetLong() / 10000;

    public double GetDoubleCurrency() => GetLong() / 10000.0;

    public void Dispose()
    {
        _file.Close();
    }
}
