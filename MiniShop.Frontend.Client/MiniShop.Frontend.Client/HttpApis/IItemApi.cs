using MiniShop.Frontend.Client.Attributes;
using System;
using System.Collections.Generic;
using WebApiClientCore;
using WebApiClientCore.Attributes;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.HttpApis
{
    [MiniShopApi]
    [SetAccessToken]
    [JsonReturn]
    public interface IItemApi : IHttpApi
    {
        [HttpGet("/api/item/GetListAllByShopIdAsync")]
        ITask<ResultModel<List<dynamic>>> GetListAllByShopIdAsync(Guid shopId, bool isDescending = false);
    }
}
