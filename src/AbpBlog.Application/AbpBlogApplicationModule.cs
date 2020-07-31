using AbpBlog.Application;
using AbpBlog.Application.Caching;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace AbpBlog
{
    [DependsOn(
         typeof(AbpIdentityApplicationModule),
         typeof(AbpAutoMapperModule),
         typeof(AbpBlogApplicationCachingModule)
     )]
    public class AbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(option => 
            {
                option.AddMaps<AbpBlogApplicationModule>(validate:true);
                option.AddProfile<AbpBlogAutoMapperProfile>(validate:true);
            });
        }
    }
}
