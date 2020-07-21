using AbpBlog.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace AbpBlog
{
    [DependsOn(
     typeof(AbpBlogFrameworkCoreModule)
    )]
    public class AbpBlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpBlogMigrationsDbContext>();
        }
    }
}
