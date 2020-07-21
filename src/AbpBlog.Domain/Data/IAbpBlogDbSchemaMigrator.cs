using System.Threading.Tasks;

namespace AbpBlog.Data
{
    public interface IAbpBlogDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
