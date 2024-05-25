﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MiniShop.Backend.Api.Config;
using System;

namespace MiniShop.Backend.Api.Code.Attributes
{
    /// <summary>
    /// 自定义路由 /api/{version}/[controler]
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomRouteAttribute : RouteAttribute, IApiDescriptionGroupNameProvider
    {

        /// <summary>
        /// 分组名称,是来实现接口 IApiDescriptionGroupNameProvider
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 自定义路由构造函数，继承基类路由
        /// </summary>
        /// <param name="actionName">[action]</param>
        public CustomRouteAttribute(string actionName = "") : base("/api/{version}/[controller]/" + actionName)
        {
        }
        /// <summary>
        /// 自定义版本+路由构造函数，继承基类路由
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="version"></param>
        public CustomRouteAttribute(ApiVersions version, string actionName = "") : base($"/api/{version.ToString().Replace('_', '.')}/[controller]/{actionName}")
        {
            GroupName = version.ToString().Replace('_', '.');
        }
    }
}
