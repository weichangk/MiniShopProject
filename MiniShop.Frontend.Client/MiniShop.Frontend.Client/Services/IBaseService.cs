using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniShop.Frontend.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;

namespace MiniShop.Frontend.Client.Services
{
    /// <summary>
    /// 封装公共方法CURD操作，业务相关操作请在子类中重写基类方法
    /// </summary>
    /// <typeparam name="TEntity">数据库模型</typeparam>
    /// <typeparam name="TEntityDTO">DTO模型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IBaseService<TEntity, TEntityDTO, TKey> where TEntityDTO : class where TEntity : EntityBase<TKey>, new() where TKey : struct
    {
        void AttachIfNot(TEntity entity);

        /// <summary>
        /// 工作单元
        /// </summary>
        //IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 主键查询
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<IResultModel> GetByIdAsync(TKey id);

        /// <summary>
        /// 所有数据
        /// </summary>
        /// <param name="isDescending">是否倒序排序</param>
        /// <returns></returns>
        Task<IResultModel> GetListAllAsync(bool isDescending = false);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model">DTO视图模型</param>
        /// <returns></returns>
        Task<IResultModel> InsertAsync(TEntityDTO model);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        Task<IResultModel> InsertAsync(TEntity model);

        /// <summary>
        /// 批量新增数据
        /// </summary>
        /// <param name="models">实体模型集合</param>
        /// <returns></returns>
        Task<IResultModel> InsertAsync(IEnumerable<TEntity> models);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model">DTO视图模型</param>
        /// <returns></returns>
        Task<IResultModel> UpdateAsync(TEntityDTO model);

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entitys">DTO视图模型</param>
        /// <returns></returns>
        Task<IResultModel> UpdateAsync(IEnumerable<TEntityDTO> models);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        Task<IResultModel> UpdateAsync(TEntity model);

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="models">实体模型集合</param>
        /// <returns></returns>
        Task<IResultModel> UpdateAsync(IEnumerable<TEntity> models);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<IResultModel> DeleteAsync(TKey id);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">多个主键</param>
        /// <returns></returns>
        Task<IResultModel> DeleteAsync(IList<TKey> ids);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model">实体模型</param>
        /// <returns></returns>
        Task<IResultModel> DeleteAsync(TEntity model);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="models">实体模型集合</param>
        /// <returns></returns>
        Task<IResultModel> DeleteAsync(IEnumerable<TEntity> models);

        #region BulkExtensions 有问题
        Task<IResultModel> BulkInsertAsync(IList<TEntity> entities);
        Task<IResultModel> BulkUpdateAsync(IList<TEntity> entities);
        Task<IResultModel> BulkDeleteAsync(IList<TEntity> entities);
        Task<IResultModel> BulkInsertOrUpdateAsync(IList<TEntity> entities);
        Task<IResultModel> BulkInsertOrUpdateOrDeleteAsync(IList<TEntity> entities);
        Task<IResultModel> BulkReadAsync(IList<TEntity> entities);
        #endregion
    }
}
