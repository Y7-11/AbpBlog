using AbpBlog.Domain.Blog;
using AbpBlog.Domain.Wallpaper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AbpBlog.EntityFrameworkCore
{
    [ConnectionStringName("SqlServer")]
    public class AbpBlogDbContext : AbpDbContext<AbpBlogDbContext>
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<FriendLink> FriendLinks { get; set; }

        public DbSet<Wallpaper> Wallpapers { get; set; }

        public AbpBlogDbContext(DbContextOptions<AbpBlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
