using MiniShop.Frontend.Client.Dtos;
using MiniShop.Frontend.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.Services
{
    public interface IItemService : IBaseService<Item, ItemDto, int>
    {
        Task<IResultModel> GetByItemIdAsync(int itemId);
        Task<IResultModel> InsertOrUpdateAsync(IEnumerable<Item> models);
    }
}
