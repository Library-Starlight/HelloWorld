using AlarmCenterGrpcClient.Proxy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Runtime.CompilerServices;
using static HelloWorld.DI.FrameworkDI;

public class ModuleInitializer
{
    /// <summary>
    /// 初始化依赖注入服务
    /// </summary>
    [ModuleInitializer]
    internal static void DIInit()
    {
        Services = new();
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        Services.AddSingleton(configuration)
            .AddIotExtension(configuration, null)
            .AddClientAppService();

        IoTServiceProvider = Services.BuildServiceProvider();
    }
}
