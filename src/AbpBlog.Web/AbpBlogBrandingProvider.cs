﻿using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace AbpBlog.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpBlogBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpBlog";
    }
}
