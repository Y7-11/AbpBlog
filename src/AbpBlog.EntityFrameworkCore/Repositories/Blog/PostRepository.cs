using AbpBlog.Domain.Blog;
using AbpBlog.Domain.Blog.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpBlog.EntityFrameworkCore.Repositories.Blog
{
    public class PostRepository: EfCoreRepository<AbpBlogDbContext,Post,int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<AbpBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }
    }
}
