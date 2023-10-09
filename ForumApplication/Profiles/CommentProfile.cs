using AutoMapper;

namespace ForumApplication.API.Profiles
{
    public class CommentProfile : Profile
    {
        // For mapper
        public CommentProfile()
        {
            CreateMap<Entities.Comment, Models.CommentDto>();
            CreateMap<Models.CreateCommentDto,Entities.Comment>();
        }
    }
}
