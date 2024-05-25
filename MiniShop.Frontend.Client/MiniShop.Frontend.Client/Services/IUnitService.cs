using MiniShop.Frontend.Client.Dtos;
using MiniShop.Frontend.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.Services
{
    public interface IUnitService : IBaseService<Unit, UnitDto, int>
    {
        Task<IResultModel> GetByUnitIdAsync(int unitId);
        Task<IResultModel> InsertOrUpdateAsync(IEnumerable<Unit> models);
    }
}
