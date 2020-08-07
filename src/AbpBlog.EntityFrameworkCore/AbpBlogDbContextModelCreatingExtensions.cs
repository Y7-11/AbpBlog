using AbpBlog.Domain.Blog;
using AbpBlog.Domain.HotNews;
using AbpBlog.Domain.Shared;
using AbpBlog.Domain.Wallpaper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using static AbpBlog.Domain.Shared.AbpBlogDbConsts;

namespace AbpBlog.EntityFrameworkCore
{
    public static class AbpBlogDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Post>(b => 
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Posts);
                b.HasKey(e => e.Id);
                b.Property(e => e.Title).HasMaxLength(200).IsRequired();
                b.Property(e => e.Author).HasMaxLength(10);
                b.Property(e => e.Url).HasMaxLength(100).IsRequired();
                b.Property(e => e.Html).HasColumnType("nvarchar(max)").IsRequired();
                b.Property(e => e.Markdown).HasColumnType("nvarchar(max)").IsRequired();
                b.Property(x => x.CategoryId).HasColumnType("int");
                b.Property(x => x.CreationTime).HasColumnType("datetime");
            });

            builder.Entity<Tag>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Tags);
                b.HasKey(x => x.Id);
                b.Property(x => x.TagName).HasMaxLength(50).IsRequired();
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<PostTag>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.PostTags);
                b.HasKey(x => x.Id);
                b.Property(x => x.PostId).HasColumnType("int").IsRequired();
                b.Property(x => x.TagId).HasColumnType("int").IsRequired();
            });

            builder.Entity<FriendLink>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Friendlinks);
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(20).IsRequired();
                b.Property(x => x.LinkUrl).HasMaxLength(100).IsRequired();
            });

            builder.Entity<Wallpaper>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Wallpapers);
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd();
                b.Property(x => x.Url).HasMaxLength(200).IsRequired();
                b.Property(x => x.Title).HasMaxLength(100).IsRequired();
                b.Property(x => x.Type).HasColumnType("int").IsRequired();
                b.Property(x => x.CreateTime).HasColumnType("datetime").IsRequired();
            });

            builder.Entity<HotNews>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.HotNews);
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd();
                b.Property(x => x.Title).HasMaxLength(200).IsRequired();
                b.Property(x => x.Url).HasMaxLength(250).IsRequired();
                b.Property(x => x.SourceId).HasColumnType("int").IsRequired();
                b.Property(x => x.CreateTime).HasColumnType("datetime").IsRequired();
            });
        }
    }
}
