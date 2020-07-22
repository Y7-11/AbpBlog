using AbpBlog.Application.Contracts.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AbpBlog.ToolKits.Base;

namespace AbpBlog.Application.Blog
{
    public interface IBlogService
    {
        //Task<bool> InsertPostAsync(PostDto dto);
        Task<ServiceResult<string>> InsertPostAsync(PostDto dto);

        //Task<bool> DeletePostAsync(int id);
        Task<ServiceResult> DeletePostAsync(int id);

        //Task<bool> UpdatePostAsync(int id, PostDto dto);
        Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto);

        //Task<PostDto> GetPostAsync(int id);
        Task<ServiceResult<PostDto>> GetPostAsync(int id);
    }
}
