using AbpBlog.ToolKits.Helper;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AbpBlog.HttpApi.Hosting.Filters
{
    public class AbpBlogExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 日志记录
            LoggerHelper.WriteToFile($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
