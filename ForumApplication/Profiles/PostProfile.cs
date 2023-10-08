using AutoMapper;

namespace ForumApplication.API.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile() { 
            CreateMap<Entities.Post, Models.PostWithoutCommentsDto>();
            CreateMap< Models.UpdatePostDto, Entities.Post>();
            CreateMap<Entities.Post, Models.PostDto>();
            CreateMap< Models.CreatePostDto, Entities.Post>();
        }
    }
}
