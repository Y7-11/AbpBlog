using AbpBlog.Application.Contracts.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbpBlog.Application.Blog
{
    public interface IBlogService
    {
        Task<bool> InsertPostAsync(PostDto dto);
        Task<bool> DeletePostAsync(int id);
        Task<bool> UpdatePostAsync(int id, PostDto dto);
        Task<PostDto> GetPostAsync(int id);
    }
}
