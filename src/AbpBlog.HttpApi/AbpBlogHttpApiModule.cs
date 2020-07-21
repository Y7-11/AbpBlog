using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace AbpBlog
{
    [DependsOn(
         typeof(AbpIdentityHttpApiModule),
         typeof(AbpBlogApplicationModule)
     )]
    public class AbpBlogHttpApiModule : AbpModule
    {
        
    }
}
