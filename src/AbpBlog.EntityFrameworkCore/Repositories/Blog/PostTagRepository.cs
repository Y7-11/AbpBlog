using AbpBlog.Domain.Blog;
using AbpBlog.Domain.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpBlog.EntityFrameworkCore.Repositories.Blog
{
    public class PostTagRepository : EfCoreRepository<AbpBlogDbContext, PostTag, int>, IPostTagRepository
    {
        public PostTagRepository(IDbContextProvider<AbpBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="postTags"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<PostTag> postTags)
        {
            await DbContext.Set<PostTag>().AddRangeAsync(postTags);
            await DbContext.SaveChangesAsync();
        }
    }
}
