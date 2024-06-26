﻿using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace CommonTools.Core.Helper
{
    public static class ConsulHelper
    {
        /// <summary>
        /// 服务注册到 consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IConfiguration configuration, IHostApplicationLifetime lifetime)
        {
            var consulClient = new ConsulClient(c =>
            {
                // consul地址
                c.Address = new Uri(configuration["ConsulSetting:ConsulAddress"]);
            });

            var servicePort = Environment.GetEnvironmentVariable("SERVICEPORT");// 服务端口 如果要运行多个实例，端口不能在appsettings.json里配置，在 docker 容器运行时传入环境变量指定端口
            var registration = new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(),// 服务实例唯一标识
                Name = configuration["ConsulSetting:ServiceName"],// 服务名
                Address = configuration["ConsulSetting:ServiceIP"], // 服务IP
                Port = string.IsNullOrEmpty(servicePort) ? int.Parse(configuration["ConsulSetting:ServicePort"]) : int.Parse(servicePort),
                Check = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),// 服务启动多久后注册
                    Interval = TimeSpan.FromSeconds(10),// 健康检查时间间隔
                    HTTP = $"http://{configuration["ConsulSetting:ServiceIP"]}:{configuration["ConsulSetting:ServicePort"]}{configuration["ConsulSetting:ServiceHealthCheck"]}",//健康检查地址
                    Timeout = TimeSpan.FromSeconds(5)// 超时时间
                }
            };

            // 服务注册
            consulClient.Agent.ServiceRegister(registration).Wait();

            // 应用程序终止时，取消注册
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }

}
