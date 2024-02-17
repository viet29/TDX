using API.DTO;
using API.Entities;
using API.Entities.Requests;
using API.Entities.Responses;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // User Mapping
            CreateMap<User, UserResponse>().ForMember(des => des.AvatarUrl, opt => opt.MapFrom(src => src.AvatarImg.Url));
            CreateMap<User, UserAuthResponse>().ForMember(des => des.AvatarUrl, opt => opt.MapFrom(src => src.AvatarImg.Url));
            CreateMap<UserUpdateDTO, User>();
            CreateMap<RegisterRequest, User>();

            // Photo Mapping
            CreateMap<Photo, PhotoDTO>();

            // Faq Mapping
            CreateMap<FaqRequest, Faq>();
            CreateMap<Faq, FaqResponse>();

            // Article Mapping
            CreateMap<ArticleRequest, Article>();
            CreateMap<Article, ArticleResponse>().ForMember(des => des.AuthorName, opt => opt.MapFrom(src => src.User.FullName));
            CreateMap<Article, ArticleDetailResponse>().ForMember(des => des.AuthorName, opt => opt.MapFrom(src => src.User.FullName));
        }
    }
}
