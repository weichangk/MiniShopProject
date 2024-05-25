using MediaKitWpfApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;

namespace MediaKitWpfApp.Repositores
{
    public interface ISysParmBaseRepository : IBaseRepository<SysParm, int>
    {
        Task<IResultModel> GetByKeyAndTypeAsync(string key, string type);
        Task<IResultModel> InsertOrUpdateValueByKeyAndTypeAsync(string key, string type, string value);
    }
}
