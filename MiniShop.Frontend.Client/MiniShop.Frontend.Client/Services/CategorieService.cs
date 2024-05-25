using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniShop.Frontend.Client.Dtos;
using MiniShop.Frontend.Client.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weick.Orm.Core;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.Services
{
    public class CategorieService : BaseService<Categorie, CategorieDto, int>, ICategorieService, IDependency
    {
        public CategorieService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger logger, Lazy<IRepository<Categorie>> repository) : base(mapper, unitOfWork, logger, repository)
        {
        }

        public async Task<IResultModel> GetByCategorieIdAsync(int categorieId)
        {
            var data = await _repository.Value.TableNoTracking.Where(s => s.CategorieId == categorieId).FirstOrDefaultAsync();
            return ResultModel.Success(data);
        }

        public async Task<IResultModel> InsertOrUpdateAsync(IEnumerable<Categorie> models)
        {
            List<Categorie> exists = new List<Categorie>();
            List<Categorie> noExists = new List<Categorie>();
            foreach (var item in models)
            {
                var getResult = (ResultModel<Categorie>)(await GetByCategorieIdAsync(item.CategorieId));
                if (getResult.Success)
                {
                    if (getResult.Data != null)
                    {
                        item.Id = getResult.Data.Id;
                        exists.Add(item);
                    }
                    else
                    {
                        item.Id = 0;
                        noExists.Add(item);
                    }
                }
                else
                {
                    _logger.Error($"error：InsertOrUpdate failed");
                    return ResultModel.Failed("error：InsertOrUpdate failed", 500);
                }
            }

            bool execInsertOrUpdate = false;
            if (exists.Any())
            {
                _repository.Value.Update(exists);
                execInsertOrUpdate = true;
            }

            if (noExists.Any())
            {
                await _repository.Value.InsertAsync(noExists);
                execInsertOrUpdate = true;
            }

            if (execInsertOrUpdate)
            {
                if (await UnitOfWork.SaveChangesAsync() > 0)
                {
                    return ResultModel.Success();
                }
                else
                {
                    _logger.Error($"error：InsertOrUpdate failed");
                    return ResultModel.Failed("error：InsertOrUpdate failed", 500);
                }
            }
            return ResultModel.Success();
        }
    }
}
