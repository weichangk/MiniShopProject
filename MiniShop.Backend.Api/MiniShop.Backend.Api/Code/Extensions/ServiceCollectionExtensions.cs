﻿using Weick.MemoryCache;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MiniShop.Backend.Api.Code.Filters;
using MiniShop.Backend.Api.Code.Middleware;
using MiniShop.Backend.Api.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Weick.CommonTools.Core.Extensions;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Api.Ids;
using Microsoft.AspNetCore.Identity;
using MiniShop.Backend.Api.Code.Security;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加WebHost
        /// </summary>
        /// <param name="services"></param>
        /// <param name="env">环境</param>
        /// <returns></returns>
        public static IServiceCollection AddWebHost(this IServiceCollection services, IWebHostEnvironment env)
        {
            //Ids
            services.AddIdsConn(BasicSetting.Setting);

            //将控制器的寄宿器转为注册的服务
            services.AddControllers(options =>
            {
                options.Filters.Add<ActionFilter>();
                //options.Filters.Add(typeof(MyAuthorizeFilter));
            }).AddControllersAsServices().AddNewtonsoftJson(options =>
            {
                //设置日期格式化
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }).SetCompatibilityVersion(AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddOptions();

            //添加所有通过特性注入的服务
            services.AddNetModularServices();

            //服务端缓存
            services.AddResponseCaching();

            //添加缓存
            services.AddCache();

            //添加CORS
            services.AddCors(BasicSetting.Setting);

            //添加ORM
            services.AddORM(BasicSetting.Setting);

            //数据库迁移
            services.AddInitDB();

            //注册懒加载，与Autofac冲突，使用懒加载禁用Autofac注入方式。
            services.AddTransient(typeof(Lazy<>));

            //添加AutoMapper
            services.AddAutoMapper(typeof(MiniShop.Backend.Model.Dto.Profiles.AutoMapperProfiles).Assembly);

            //添加Swagger
            if (env.IsDevelopment())
            {
                services.AddSwagger();
            }

            //身份认证
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = BasicSetting.Setting.AuthenticationAuthority;
                options.ApiName = BasicSetting.Setting.AuthenticationMiniShopBackendApiName;
                options.RequireHttpsMetadata = false;
                options.ApiSecret = BasicSetting.Setting.AuthenticationMiniShopBackendApiSecret;
                //options.JwtValidationClockSkew = TimeSpan.FromSeconds(0);//时间偏移
            });

            //身份授权
            services.AddAuthorization(options =>
            {
                options.AddPolicy("NoOwePolicy", policy => policy.AddRequirements(new NoOweRequirement()));
                //options.InvokeHandlersAfterFailure = false;
            });
            // services.AddSingleton<IAuthorizationHandler>(x => new NoOweHandler((MiniShop.IServices.IShopService)services.BuildServiceProvider()
            //         .GetService(typeof(MiniShop.IServices.IShopService))));

            //开启模型验证结果格式化
            services.AddValidators();

            //解决Multipart body length limit 134217728 exceeded
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
            });

            return services;
        }

        /// <summary>
        /// 注册Swagger生成器
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //遍历出全部的版本，做文档信息展示
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    version = version.Replace('_', '.');
                    c.SwaggerDoc(version, new OpenApiInfo
                    {
                        Version = version,
                        Title = $"{BasicSetting.Setting.AssemblyName} 接口文档 - NetCore 3.1",
                        Description = $"{BasicSetting.Setting.AssemblyName} HTTP API " + version,
                    });
                    c.OrderActionsBy(o => o.RelativePath);
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, BasicSetting.Setting.AssemblyName + ".xml");
                c.IncludeXmlComments(filePath);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT认证请求头格式: \"Token: {token}\"",
                    Name = "Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };

                //添加设置Token的按钮
                c.AddSecurityDefinition("Bearer", securityScheme);

                //添加Jwt验证设置
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                //链接转小写过滤器
                c.DocumentFilter<LowercaseDocumentFilter>();

                //描述信息处理
                c.DocumentFilter<DescriptionDocumentFilter>();

                //隐藏属性
                c.SchemaFilter<IgnorePropertySchemaFilter>();

                //表单模型处理
                c.RequestBodyFilter<IgnorePropertyRequestBodyFilter>();
            });
            //支持newstonsoftjson
            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        /// <summary>
        /// 添加CORS允许跨域访问
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static IServiceCollection AddCors(this IServiceCollection services, BasicSetting setting)
        {
            if (setting.WithOrigins != null && setting.WithOrigins.Length > 0)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("AnotherPolicy",
                        builder =>
                        {
                            builder.WithOrigins(setting.WithOrigins)
                            .SetPreflightMaxAge(new TimeSpan(0, 0, 180))
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        });
                });
            }
            else
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("Default",
                        builder => builder.AllowAnyOrigin()
                            .SetPreflightMaxAge(new TimeSpan(0, 0, 180))
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                });
            }
            return services;
        }

        /// <summary>
        /// 添加ORM
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static IServiceCollection AddORM(this IServiceCollection services, BasicSetting setting)
        {
            // 使用环境变量配置数据库连接字符串，兼容在 docker-compose 使用环境变量设置连接字符串构建部署
            var prodconn = System.Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            if (!string.IsNullOrEmpty(prodconn))
            {
                setting.ConnectionString = prodconn;
            }
            if (setting.DbType == Weick.Orm.Core.DbType.MYSQL)
            {
                //UseLazyLoadingProxies 通过延迟加载获取导航属性数据
                services.AddChimp<AppDbContext>(opt => opt.UseLazyLoadingProxies().UseMySql(setting.ConnectionString,
                    b => b.MigrationsAssembly(setting.AssemblyName)));
            }
            else
            {
                services.AddChimp<AppDbContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(setting.ConnectionString,
                    b => b.MigrationsAssembly(setting.AssemblyName)));
            }
            return services;
        }

        /// <summary>
        /// 开启模型验证结果格式化
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.TryAddSingleton<IValidateResultFormatHandler, ValidateResultFormatHandler>();
            return services;
        }

        /// <summary>
        /// Ids连接服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static IServiceCollection AddIdsConn(this IServiceCollection services, BasicSetting setting)
        {
            services.AddDbContext<IdsDbContext>(options =>
                options.UseMySql(setting.IdsConnectionString));
                    services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddErrorDescriber<CustomIdentityErrorDescriber>()
                        .AddEntityFrameworkStores<IdsDbContext>()
                        .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddInitDB(this IServiceCollection services)
        {
            Log.Information("Migrate database...");
            using var context = services.BuildServiceProvider().GetService<AppDbContext>();
            context.Database.Migrate();
            Log.Information("Done Migrate database.");

            return services;
        }
    }
}
