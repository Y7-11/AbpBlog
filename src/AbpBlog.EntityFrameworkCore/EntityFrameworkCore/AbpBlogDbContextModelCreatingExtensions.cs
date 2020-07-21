﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpBlog.EntityFrameworkCore
{
    public static class AbpBlogDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpBlog(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpBlogConsts.DbTablePrefix + "YourEntities", AbpBlogConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}