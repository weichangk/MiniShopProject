using System.Collections.Generic;

namespace Weick.Orm.Core
{
    public interface IPagedList<out T>
    {
        int Current { get; }

        int PageSize { get; }

        int Total { get; }

        int PageTotal { get; }

        IEnumerable<T> Item { get; }
    }
}
