using AbpBlog.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace AbpBlog.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpBlogDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
    public class AbpBlogFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpBlogDbContext>(option => 
            {
                option.AddDefaultRepositories(includeAllEntities:true);
            });

            Configure<AbpDbContextOptions>(option =>
            {
                switch (AppSettings.EnableDb)
                {
                    case "SqlServer":
                        option.UseSqlServer();
                        break;
                    default:
                        option.UseSqlServer();
                        break;
                }
            });
        }
    }
}
