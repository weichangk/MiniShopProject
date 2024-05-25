using Dapper;
using MediaKitWpfApp.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weick.Orm.Core;
using Weick.Orm.Core.Result;

namespace MediaKitWpfApp.Repositores
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : EntityBase<TKey>, new() where TKey : struct
    {
        protected readonly ILogger _logger;
        protected readonly Lazy<IRepository<TEntity>> _repository;
        public IUnitOfWork UnitOfWork { get; }

        public BaseRepository(IUnitOfWork unitOfWork, ILogger logger,
           Lazy<IRepository<TEntity>> repository)
        {
            UnitOfWork = unitOfWork;
            _logger = logger;
            _repository = repository;
        }

        public void AttachIfNot(TEntity entity)
        {
            _repository.Value.AttachIfNot(entity);
        }

        public virtual async Task<IResultModel> DeleteAsync(TKey id)
        {
            var entity = await _repository.Value.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.Error($"error：entity Id：{id} does not exist");
                return ResultModel.NotExists;
            }
            _repository.Value.Delete(entity);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Remove failed");
            return ResultModel.Failed("error：Delete failed", 500);
        }

        public virtual async Task<IResultModel> DeleteAsync(IList<TKey> ids)
        {
            foreach (var id in ids)
            {
                var entity = await _repository.Value.GetByIdAsync(id);
                if (entity == null)
                {
                    _logger.Error($"error：entity Id：{id} does not exist");
                    return ResultModel.NotExists;
                }
                _repository.Value.Delete(entity);
            }
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Delete failed");
            return ResultModel.Failed("error：Remove failed", 500);
        }

        public virtual async Task<IResultModel> DeleteAsync(TEntity model)
        {
            _repository.Value.Delete(model);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Remove failed");
            return ResultModel.Failed("error：Delete failed", 500);
        }

        public virtual async Task<IResultModel> DeleteAsync(IEnumerable<TEntity> models)
        {
            _repository.Value.Delete(models);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Delete failed");
            return ResultModel.Failed("error：Remove failed", 500);
        }

        public virtual async Task<IResultModel> GetByIdAsync(TKey id)
        {
            var info = await _repository.Value.GetByIdAsync(id);
            return ResultModel.Success(info);
        }

        public virtual async Task<IResultModel> GetListAllAsync(bool isDescending = false)
        {
            if (isDescending)
            {
                var Descendinglist = await _repository.Value.TableNoTracking.OrderByDescending(k => k.Id).ToListAsync();
                return ResultModel.Success(Descendinglist);
            }
            var list = await _repository.Value.TableNoTracking.OrderBy(k => k.Id).ToListAsync();
            return ResultModel.Success(list);
        }

        public virtual async Task<IResultModel> InsertAsync(TEntity model)
        {
            await _repository.Value.InsertAsync(model);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Insert Save failed");
            return ResultModel.Failed("error：Insert Save failed", 500);
        }

        public virtual async Task<IResultModel> InsertAsync(IEnumerable<TEntity> models)
        {
            await _repository.Value.InsertAsync(models);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Insert Save failed");
            return ResultModel.Failed("error：Insert Save failed", 500);
        }

        public virtual async Task<IResultModel> UpdateAsync(TEntity model)
        {
            _repository.Value.Update(model);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Update Save failed");
            return ResultModel.Failed("error：Update Save failed", 500);
        }

        public virtual async Task<IResultModel> UpdateAsync(IEnumerable<TEntity> models)
        {
            _repository.Value.Update(models);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Updates Save failed");
            return ResultModel.Failed("error：Updates Save failed", 500);
        }
    }
}
