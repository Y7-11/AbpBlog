﻿using AbpBlog.Domain.Blog;
using AbpBlog.Domain.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpBlog.EntityFrameworkCore.Repositories.Blog
{
    public class FriendLinkRepository : EfCoreRepository<AbpBlogDbContext, FriendLink, int>, IFriendLinkRepository
    {
        public FriendLinkRepository(IDbContextProvider<AbpBlogDbContext> dbContextProvider):base(dbContextProvider)
        {

        }
    }
}
