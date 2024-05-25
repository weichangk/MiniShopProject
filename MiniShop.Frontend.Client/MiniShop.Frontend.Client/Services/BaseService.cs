using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniShop.Frontend.Client.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Weick.Orm.Core;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.Services
{
    public class BaseService<TEntity, TEntityDTO, TKey> : IBaseService<TEntity, TEntityDTO, TKey> where TEntityDTO : class where TEntity : EntityBase<TKey>, new() where TKey : struct
    {
        protected readonly ILogger _logger;
        protected readonly Lazy<IMapper> _mapper;

        /// <summary>
        /// TEntity仓储
        /// </summary>
        protected readonly Lazy<IRepository<TEntity>> _repository;
        /// <summary>
        /// 工作单元
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }

        public BaseService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger logger,
           Lazy<IRepository<TEntity>> repository)
        {
            _logger = logger;
            _mapper = mapper;
            UnitOfWork = unitOfWork;
            this._repository = repository;
        }

        public void AttachIfNot(TEntity entity)
        {
            _repository.Value.AttachIfNot(entity);
        }

        public virtual async Task<IResultModel> GetByIdAsync(TKey id)
        {
            var info = await _repository.Value.GetByIdAsync(id);
            return ResultModel.Success(_mapper.Value.Map<TEntityDTO>(info));
        }

        public virtual async Task<IResultModel> GetListAllAsync(bool isDescending = false)
        {
            if (isDescending)
            {
                var Descendinglist = await _repository.Value.TableNoTracking.OrderByDescending(k => k.Id).ProjectTo<TEntityDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
                return ResultModel.Success(Descendinglist);
            }
            var list = await _repository.Value.TableNoTracking.OrderBy(k => k.Id).ProjectTo<TEntityDTO>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public virtual async Task<IResultModel> InsertAsync(TEntityDTO model)
        {
            var entity = _mapper.Value.Map<TEntity>(model);
            await _repository.Value.InsertAsync(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(_mapper.Value.Map<TEntityDTO>(entity));
            }
            _logger.Error($"error：Insert Save failed");
            return ResultModel.Failed("error：Insert Save failed", 500);
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

        public virtual async Task<IResultModel> UpdateAsync(TEntityDTO model)
        {
            //主键判断
            var entity = await _repository.Value.GetByIdAsync(((dynamic)model).Id);
            if (entity == null)
            {
                _logger.Error($"error：entity Id {((dynamic)model).Id} does not exist");
                return ResultModel.NotExists;
            }
            _mapper.Value.Map(model, entity);
            _repository.Value.Update(entity);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success(entity);
            }
            _logger.Error($"error：Update Save failed");
            return ResultModel.Failed("error：Update Save failed", 500);
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

        public virtual async Task<IResultModel> UpdateAsync(IEnumerable<TEntityDTO> models)
        {
            var entitys = new List<TEntity>();
            foreach (var model in models)
            {
                //主键判断
                var entity = await _repository.Value.GetByIdAsync(((dynamic)model).Id);
                if (entity == null)
                {
                    _logger.Error($"error：entity Id {((dynamic)model).Id} does not exist");
                    return ResultModel.NotExists;
                }
                _mapper.Value.Map(model, entity);
                entitys.Add(entity);
            }
            _repository.Value.Update(entitys);

            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            _logger.Error($"error：Updates Save failed");
            return ResultModel.Failed("error：Updates Save failed", 500);
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

        public virtual async Task<IResultModel> DeleteAsync(TKey id)
        {
            //主键判断
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

        public virtual async Task<IResultModel> DeleteAsync(IList<TKey> ids)
        {
            foreach (var id in ids)
            {
                //主键判断
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

        #region BulkExtensions
        public async Task<IResultModel> BulkInsertAsync(IList<TEntity> entities)
        {
            if (!entities.Any())
                return ResultModel.Failed("error：entities No elements", 500);

            await _repository.Value.BulkInsertAsync(entities);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                _logger.Error($"error：BulkInsert failed");
                return ResultModel.Failed("error：BulkInsert failed", 500);
            }
        }
        public async Task<IResultModel> BulkUpdateAsync(IList<TEntity> entities)
        {
            if (!entities.Any())
                return ResultModel.Failed("error：entities No elements", 500);

            await _repository.Value.BulkUpdateAsync(entities);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                _logger.Error($"error：BulkUpdate failed");
                return ResultModel.Failed("error：BulkUpdate failed", 500);
            }
        }
        public async Task<IResultModel> BulkDeleteAsync(IList<TEntity> entities)
        {
            if (!entities.Any())
                return ResultModel.Failed("error：entities No elements", 500);

            await _repository.Value.BulkDeleteAsync(entities);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                _logger.Error($"error：BulkDelete failed");
                return ResultModel.Failed("error：BulkDelete failed", 500);
            }
        }
        public async Task<IResultModel> BulkInsertOrUpdateAsync(IList<TEntity> entities)
        {
            if (!entities.Any())
                return ResultModel.Failed("error：entities No elements", 500);

            await _repository.Value.BulkInsertOrUpdateAsync(entities);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                _logger.Error($"error：BulkInsertOrUpdate failed");
                return ResultModel.Failed("error：BulkInsertOrUpdate failed", 500);
            }
        }
        public async Task<IResultModel> BulkInsertOrUpdateOrDeleteAsync(IList<TEntity> entities)
        {
            if (!entities.Any())
                return ResultModel.Failed("error：entities No elements", 500);

            await _repository.Value.BulkInsertOrUpdateOrDeleteAsync(entities);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                _logger.Error($"error：BulkInsertOrUpdateOrDelete failed");
                return ResultModel.Failed("error：BulkInsertOrUpdateOrDelete failed", 500);
            }
        }
        public async Task<IResultModel> BulkReadAsync(IList<TEntity> entities)
        {
            if (!entities.Any())
                return ResultModel.Failed("error：entities No elements", 500);

            await _repository.Value.BulkReadAsync(entities);
            if (await UnitOfWork.SaveChangesAsync() > 0)
            {
                return ResultModel.Success();
            }
            else
            {
                _logger.Error($"error：BulkRead failed");
                return ResultModel.Failed("error：BulkRead failed", 500);
            }
        }
        #endregion
    }
}
