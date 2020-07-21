using System;
using System.Collections.Generic;
using System.Text;
using AbpBlog.Localization;
using Volo.Abp.Application.Services;

namespace AbpBlog
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpBlogAppService : ApplicationService
    {
        protected AbpBlogAppService()
        {
            LocalizationResource = typeof(AbpBlogResource);
        }
    }
}
