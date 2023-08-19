using API.DTO;
using API.Entities;
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

            CreateMap<Photo, PhotoDTO>();

            CreateMap<RegisterDTO, User>();

            // Article Mapping
            CreateMap<ArticleRequest, Article>();
            CreateMap<Article, ArticleResponse>().ForMember(des => des.AuthorName, opt => opt.MapFrom(src => src.User.FullName));
            CreateMap<Article, ArticleDetailResponse>().ForMember(des => des.AuthorName, opt => opt.MapFrom(src => src.User.FullName));

            CreateMap<UserUpdateDTO, User>();
            //CreateMap<MemberUpdateDto, AppUser>();



            //CreateMap<Message, MessageDto>()
            //    .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src =>
            //        src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
            //    .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src =>
            //        src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url));
            //CreateMap<MessageDto, Message>();
        }
    }
}
