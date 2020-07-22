using AbpBlog.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace AbpBlog
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpBlogDomainSharedModule)
        )]
    public class AbpBlogDomainModule : AbpModule
    {

    }
}
