using Prism.DryIoc;
using Prism.Ioc;
using DevUpUnoDemo.Views;

namespace DevUpUnoDemo;

public class App : PrismApplication
{
    protected override UIElement CreateShell() => new Shell();

    protected override void ConfigureHost(IHostBuilder host) => host
        .UseLogging(configure: (context, logBuilder) =>
        {
            // Configure log levels for different categories of logging
            logBuilder.SetMinimumLevel(
                context.HostingEnvironment.IsDevelopment() ?
                    LogLevel.Information :
                    LogLevel.Warning);
        }, enableUnoLogging: true)
        .UseConfiguration(configure: configBuilder =>
            configBuilder
                .EmbeddedSource<App>()
        );

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<CoreModule.CoreModule>();
    }
}
