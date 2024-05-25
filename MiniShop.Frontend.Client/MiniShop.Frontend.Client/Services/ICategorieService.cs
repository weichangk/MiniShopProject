using MiniShop.Frontend.Client.Dtos;
using MiniShop.Frontend.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.Services
{
    public interface ICategorieService : IBaseService<Categorie, CategorieDto, int>
    {
        Task<IResultModel> GetByCategorieIdAsync(int categorieId);
        Task<IResultModel> InsertOrUpdateAsync(IEnumerable<Categorie> models);
    }
}
