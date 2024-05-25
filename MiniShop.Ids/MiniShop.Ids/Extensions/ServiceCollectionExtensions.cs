﻿using IdentityServer4;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniShop.Ids;
using MiniShop.Ids.Config;
using MiniShop.Ids.Data;
using MiniShop.Ids.Models;
using Serilog;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebHost(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // 配置cookie策略
            services.Configure<AspNetCore.Builder.CookiePolicyOptions>(options =>
            {
                //https://docs.microsoft.com/zh-cn/aspnet/core/security/samesite?view=aspnetcore-3.1&viewFallbackFrom=aspnetcore-3
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
            });

            // 使用环境变量配置数据库连接字符串，兼容在 docker-compose 使用环境变量设置连接字符串构建部署
            var prodconn = System.Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            if (!string.IsNullOrEmpty(prodconn))
            {
                BasicSetting.Setting.ConnectionString = prodconn;
            }
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(BasicSetting.Setting.ConnectionString));

            services.AddInitDB();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = false;//为true时发现注册时不能有重复邮件，但是修改时可以修改为重复邮件！！！
                //最少6位，包括至少1个大写字母，1个小写字母，1个数字，1个特殊字符
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                //options.SignIn.RequireConfirmedEmail = true;
                //指 在帐户被锁定之前允许的失败登录的次数。默认值为 5。
                options.Lockout.MaxFailedAccessAttempts = 5;
                //默认锁定时间为 15 分钟。
                options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(15);
            });

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
                options.IssuerUri = BasicSetting.Setting.Urls; // 颁发者身份标识
            })
                .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
                .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes())
                .AddInMemoryApiResources(IdentityServerConfig.ApiResources)
                .AddInMemoryClients(IdentityServerConfig.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    // register your IdentityServer with Google at https://console.developers.google.com
                    // enable the Google+ API
                    // set the redirect URI to https://localhost:5001/signin-google
                    options.ClientId = "copy client ID from Google here";
                    options.ClientSecret = "copy client secret from Google here";
                });

            return services;
        }

        public static IServiceCollection AddInitDB(this IServiceCollection services)
        {
            Log.Information("Migrate database...");
            using var context = services.BuildServiceProvider().GetService<ApplicationDbContext>();
            context.Database.Migrate();
            Log.Information("Done Migrate database.");

            Log.Information("Seeding database...");
            SeedData.EnsureSeedData(BasicSetting.Setting.ConnectionString);
            Log.Information("Done seeding database.");
            
            return services;
        }
    }
}
