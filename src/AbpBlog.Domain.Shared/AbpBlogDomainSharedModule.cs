using Volo.Abp.Identity;
using Volo.Abp.Modularity;


namespace AbpBlog.Domain.Shared
{
    [DependsOn(
    typeof(AbpIdentityDomainSharedModule)
    )]
    public class AbpBlogDomainSharedModule : AbpModule
    {
    }
}
