﻿using Orm.Core;

namespace MiniShop.Api.Config
{
    /// <summary>
    /// 
    /// </summary>
    public class BasicSetting
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbType DbType { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 自宿主启动IP端口
        /// </summary>
        public string Urls { get; set; } = "http://*:5002";
        /// <summary>
        /// 主程序集名称
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>
        /// CORS允许域名
        /// </summary>
        public string[] WithOrigins { get; set; }
        /// <summary>
        /// 接入webapi地址
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// Ids数据库连接字符串
        /// </summary>
        public string IdsConnectionString { get; set; }

        public string AuthenticationAuthority { get; set; }

        public string AuthenticationMiniShopApiName { get; set; }

        public string AuthenticationMiniShopApiSecret { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static BasicSetting Setting { get; set; } = new BasicSetting();
    }
}
