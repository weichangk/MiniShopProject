using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniShop.Frontend.Client.Attributes;
using MiniShop.Frontend.Client.Common;
using MiniShop.Frontend.Client.DbContexts;
using MiniShop.Frontend.Client.ViewModels;
using MiniShop.Frontend.Client.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebApiClientCore;

namespace MiniShop.Frontend.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }

                var service = App.Current.MainWindow.DataContext as IConfigureService;
                if (service != null)
                    service.Configure();
                base.OnInitialized();
            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<CashierDeskView, CashierDeskViewModel>();
            containerRegistry.RegisterForNavigation<CheckDealView, CheckDealViewModel>();
            containerRegistry.RegisterForNavigation<CheckStockView, CheckStockViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
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
            serviceCollection.AddChimp<AppDbContext>(opt => opt.UseLazyLoadingProxies().UseSqlite($@"DataSource={Environment.CurrentDirectory}\Data\Shop.db"));
            using (var context = serviceCollection.BuildServiceProvider().GetService<AppDbContext>())
            {
                context.Database.Migrate();
            }
            //AutoMapper
            serviceCollection.AddAutoMapper(typeof(Dtos.Profiles.AutoMapperProfiles).Assembly);

            //添加HttpClient相关
            var miniShopApiTypes = typeof(App).Assembly.GetTypes()
                        .Where(type => type.IsInterface
                        && ((System.Reflection.TypeInfo)type).ImplementedInterfaces != null
                        && type.GetInterfaces().Any(a => a.FullName == typeof(IHttpApi).FullName)
                        && type.IsDefined(typeof(MiniShopApiAttribute), false));
            foreach (var type in miniShopApiTypes)
            {
                serviceCollection.AddHttpApi(type);
                serviceCollection.ConfigureHttpApi(type, o =>
                {
                    o.HttpHost = new Uri(configuration["Urls:MiniShopApi"]);
                    // 符合国情的不标准时间格式，有些接口就是这么要求必须不标准
                    o.JsonSerializeOptions.Converters.Add(new WebApiClientCore.Serialization.JsonConverters.JsonDateTimeConverter("yyyy-MM-dd HH:mm:ss"));
                });
            }

            return new DryIocContainerExtension(new Container(CreateContainerRules()).WithDependencyInjectionAdapter(serviceCollection));
        }

        public static void LoginOut(IContainerProvider containerProvider)
        {
            Current.MainWindow.Hide();

            var dialog = containerProvider.Resolve<IDialogService>();

            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }

                Current.MainWindow.Show();
            });
        }
    }
}
