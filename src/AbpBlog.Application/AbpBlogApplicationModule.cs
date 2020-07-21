using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace AbpBlog
{
    [DependsOn(
         typeof(AbpIdentityApplicationModule)
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
