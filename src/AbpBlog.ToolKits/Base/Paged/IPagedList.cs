using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBlog.ToolKits.Base.Paged
{
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {
    }
}
