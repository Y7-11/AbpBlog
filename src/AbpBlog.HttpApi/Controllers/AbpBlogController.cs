using AbpBlog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpBlog.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpBlogController : AbpController
    {
        protected AbpBlogController()
        {
            LocalizationResource = typeof(AbpBlogResource);
        }
    }
}