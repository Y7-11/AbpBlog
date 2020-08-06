using AbpBlog.Application.Contracts.Blog;
using AbpBlog.Domain.Blog;
using AutoMapper;

namespace AbpBlog.Application
{
    public class AbpBlogAutoMapperProfile:Profile
    {
        public AbpBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
