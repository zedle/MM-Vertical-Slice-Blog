using AutoMapper;
using VSBlog.Features.Articles.Models;
using VSBlog.Features.Articles.Commands;
using VSBlog.Features.Comments.Models;
using VSBlog.Features.Comments.Commands;

namespace VSBlog.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Article mappings
            CreateMap<CreateArticleCommand, Article>();
            CreateMap<UpdateArticleCommand, Article>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Assuming you don't want to map the ID on update

            // Comment mappings
            CreateMap<AddCommentCommand, Comment>();
        }
    }
}
