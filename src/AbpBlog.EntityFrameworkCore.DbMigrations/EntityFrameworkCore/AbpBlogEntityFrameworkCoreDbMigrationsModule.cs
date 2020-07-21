using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpBlog.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpBlogEntityFrameworkCoreModule)
        )]
    public class AbpBlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpBlogMigrationsDbContext>();
        }
    }
}
