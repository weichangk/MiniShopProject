﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace MiniShop.Platform.Api.Code.Middleware
{
    /// <summary>
    /// 模型验证失败返回格式处理，前端MVC模式下禁用
    /// </summary>
    public interface IValidateResultFormatHandler
    {
        /// <summary>
        /// 格式化处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        void Format(ResultExecutingContext context);
    }
}
