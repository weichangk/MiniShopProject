﻿using System;

namespace MiniShop.Backend.Api.Code.Attributes
{
    /// <summary>
    /// Swagger：隐藏属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnorePropertyAttribute : Attribute
    {
    }
}
