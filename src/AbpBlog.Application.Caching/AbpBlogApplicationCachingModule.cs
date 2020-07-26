using AbpBlog.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace AbpBlog.Application.Caching
{
    [DependsOn(
           typeof(AbpCachingModule),
           typeof(AbpBlogDomainModule)
       )]
    public class AbpBlogApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(option => {
                option.Configuration = AppSettings.Caching.RedisConnectionString;
            });
        }
    }
}
