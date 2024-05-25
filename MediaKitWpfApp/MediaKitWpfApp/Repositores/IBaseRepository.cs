using MediaKitWpfApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;

namespace MediaKitWpfApp.Repositores
{
    public interface IBaseRepository<TEntity, TKey>  where TEntity : EntityBase<TKey>, new() where TKey : struct
    {
        void AttachIfNot(TEntity entity);

        //IUnitOfWork UnitOfWork { get; }

        Task<IResultModel> GetByIdAsync(TKey id);

        Task<IResultModel> GetListAllAsync(bool isDescending = false);

        Task<IResultModel> InsertAsync(TEntity model);

        Task<IResultModel> InsertAsync(IEnumerable<TEntity> models);

        Task<IResultModel> UpdateAsync(TEntity model);

        Task<IResultModel> UpdateAsync(IEnumerable<TEntity> models);

        Task<IResultModel> DeleteAsync(TKey id);

        Task<IResultModel> DeleteAsync(IList<TKey> ids);

        Task<IResultModel> DeleteAsync(TEntity model);

        Task<IResultModel> DeleteAsync(IEnumerable<TEntity> models);
    }
}
