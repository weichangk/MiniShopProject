using Prism.Ioc;
using System.Windows;
using MediaKitWpfApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Serilog;
using System;
using Microsoft.EntityFrameworkCore;
using MediaKitWpfApp.DbContexts;

namespace MediaKitWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<VideoConverterPage>();
            containerRegistry.RegisterForNavigation<VideoConverterConvertingItemList>();

            containerRegistry.RegisterForNavigation<VideoConverterWorkAreaPage>();
            containerRegistry.RegisterForNavigation<VideoCompressWorkAreaPage>();
            containerRegistry.RegisterForNavigation<VideoConverterWorkingPage>();
            containerRegistry.RegisterForNavigation<VideoCompressWorkingPage>();
            containerRegistry.RegisterForNavigation<VideoConverterWorkfinishPage>();
            containerRegistry.RegisterForNavigation<VideoCompressWorkfinishPage>();
        }

        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();

            //register configuration
            IConfigurationBuilder cfgBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration configuration = cfgBuilder.Build();
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            //register logger
            var serilogLogger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)// 将配置传给 Serilog 的提供程序 
                .Enrich.FromLogContext()//记录相关上下文信息 
                .WriteTo.File("")
                .CreateLogger();
            serviceCollection.AddSingleton<ILogger>(serilogLogger);

            //register ORM
            serviceCollection.AddChimp<AppDbContext>(opt => opt.UseLazyLoadingProxies().UseSqlite($@"DataSource={Environment.CurrentDirectory}\mediakit.db"));
            using (var context = serviceCollection.BuildServiceProvider().GetService<AppDbContext>())
            {
                context.Database.Migrate();
            }

            return new DryIocContainerExtension(new Container(CreateContainerRules()).WithDependencyInjectionAdapter(serviceCollection));
        }
    }
}
