using AbpBlog.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpBlog.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpBlogEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpBlogApplicationContractsModule)
        )]
    public class AbpBlogDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
