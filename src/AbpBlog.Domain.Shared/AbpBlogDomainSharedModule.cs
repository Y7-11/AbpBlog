using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace AbpBlog.Domain.Shared
{
    [DependsOn(
    typeof(AbpIdentityDomainModule)
    )]
    public class AbpBlogDomainSharedModule : AbpModule
    {
    }
}
