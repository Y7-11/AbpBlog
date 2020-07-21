using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace AbpBlog.EntityFrameworkCore
{
    [DependsOn(
    typeof(AbpBlogDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)

)]
    public class AbpBlogFrameworkCoreModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
