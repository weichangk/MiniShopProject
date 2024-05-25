using MediaKitWpfApp.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Weick.Orm.Core;
using Weick.Orm.Core.Result;

namespace MediaKitWpfApp.Repositores
{
    public class SysParmBaseRepository : BaseRepository<SysParm, int>, ISysParmBaseRepository, IDependency
    {
        public SysParmBaseRepository(IUnitOfWork unitOfWork, ILogger logger, Lazy<IRepository<SysParm>> repository) : base(unitOfWork, logger, repository)
        {
        }

        public async Task<IResultModel> GetByKeyAndTypeAsync(string key, string type)
        {
            var data = await _repository.Value.TableNoTracking.Where(s => s.Key == key && s.Type == type).FirstOrDefaultAsync();
            return ResultModel.Success(data);
        }

        public async Task<IResultModel> InsertOrUpdateValueByKeyAndTypeAsync(string key, string type, string value)
        {
            var data = await _repository.Value.TableNoTracking.Where(s => s.Key == key && s.Type == type).FirstOrDefaultAsync();
            if (data != null)
            {
                data.Value = value;
                _repository.Value.Update(data);
                if (await UnitOfWork.SaveChangesAsync() > 0)
                {
                    return ResultModel.Success();
                }
                _logger.Error($"error：Update Save failed");
                return ResultModel.Failed("error：Update Save failed", 500);
            }
            else
            {
                await _repository.Value.InsertAsync(new SysParm() { Key = key, Type = type, Value = value});
                if (await UnitOfWork.SaveChangesAsync() > 0)
                {
                    return ResultModel.Success();
                }
                _logger.Error($"error：Insert Save failed");
                return ResultModel.Failed("error：Insert Save failed", 500);
            }
        }
    }
}
