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
    public class UnitService : BaseService<Unit, UnitDto, int>, IUnitService, IDependency
    {
        public UnitService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger logger, Lazy<IRepository<Unit>> repository) : base(mapper, unitOfWork, logger, repository)
        {
        }

        public async Task<IResultModel> GetByUnitIdAsync(int unitId)
        {
            var data = await _repository.Value.TableNoTracking.Where(s => s.UnitId == unitId).FirstOrDefaultAsync();
            return ResultModel.Success(data);
        }

        public async Task<IResultModel> InsertOrUpdateAsync(IEnumerable<Unit> models)
        {
            List<Unit> exists = new List<Unit>();
            List<Unit> noExists = new List<Unit>();
            foreach (var item in models)
            {
                var getResult = (ResultModel<Unit>)(await GetByUnitIdAsync(item.UnitId));
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
