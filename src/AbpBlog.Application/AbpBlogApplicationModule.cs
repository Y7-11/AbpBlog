using AbpBlog.Application.Caching;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace AbpBlog
{
    [DependsOn(
         typeof(AbpIdentityApplicationModule),
        typeof(AbpBlogApplicationCachingModule)
     )]
    public class AbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpAutoMapperOptions>(options =>
            //{
            //    options.AddMaps<AbpBlogApplicationModule>();
            //});
        }
    }
}
