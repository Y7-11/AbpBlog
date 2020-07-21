using AbpBlog.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpBlog.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AbpBlogPageModel : AbpPageModel
    {
        protected AbpBlogPageModel()
        {
            LocalizationResourceType = typeof(AbpBlogResource);
        }
    }
}