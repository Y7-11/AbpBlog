using AbpBlog.ToolKits.Helper;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AbpBlog.HttpApi.Hosting.Filters
{
    public class AbpBlogExceptionFilter : IExceptionFilter
    {
        private readonly ILog _log;
        public AbpBlogExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(AbpBlogExceptionFilter));
        }
        public void OnException(ExceptionContext context)
        {
            // 日志记录
            // LoggerHelper.WriteToFile($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
