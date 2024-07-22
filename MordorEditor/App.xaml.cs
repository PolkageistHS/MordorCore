using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MordorEditor;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private readonly IHost _host;

    public App()
    {
        IHostBuilder configureServices = Host.CreateDefaultBuilder()
                                             .ConfigureServices(ConfigureDelegate());
        _host = configureServices.Build();
    }

    private static Action<HostBuilderContext, IServiceCollection> ConfigureDelegate() => (_, services) =>
    {
        services.AddTransient<MainWindow>();
    };

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();
        _host.Services
             .GetRequiredService<MainWindow>()
             .Show();
    }
}
