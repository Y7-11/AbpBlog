using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpBlog.Data
{
    /* This is used if database provider does't define
     * IAbpBlogDbSchemaMigrator implementation.
     */
    public class NullAbpBlogDbSchemaMigrator : IAbpBlogDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}