using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace AbpBlog.Application.Caching
{
    [DependsOn(
           typeof(AbpCachingModule),
           typeof(AbpBlogDomainModule)
       )]
    public class MeowvBlogApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
