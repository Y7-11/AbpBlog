using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace AbpBlog
{
    [DependsOn(
        typeof(AbpIdentityDomainModule)
        )]
    public class AbpBlogDomainModule : AbpModule
    {

    }
}
