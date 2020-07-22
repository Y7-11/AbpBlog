using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpBlog.Domain.Blog.Repositories
{
    /// <summary>
    /// ITagRepository
    /// </summary>
    public interface ITagRepository : IRepository<Tag, int>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task BulkInsertAsync(IEnumerable<Tag> tags);
    }
}
