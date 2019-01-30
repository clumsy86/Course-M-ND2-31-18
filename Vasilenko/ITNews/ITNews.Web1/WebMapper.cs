using AutoMapper;
using ITNews.Domain.Contracts.Entities;
using ITNews.Web1.Models;

namespace ITNews.Web1
{
    public class WebMapper: Profile
    {
        public WebMapper()
        {
            CreateMap<PostDomainModel, PostViewModel>().ReverseMap();
            CreateMap<CategoryDomainModel, CategoryViewModel>().ReverseMap();
            CreateMap<CommentDomainModel, CommentViewModel>().ReverseMap();
            CreateMap<LikeDomainModel, LikeViewModel>().ReverseMap();
            CreateMap<PostTagDomainModel, PostTagViewModel>().ReverseMap();
            CreateMap<PostRatingDomainModel, PostRatingViewModel>().ReverseMap();
            CreateMap<ProfileDomainModel, ProfileViewModel>().ReverseMap();
            CreateMap<TagDomainModel, TagViewModel>().ReverseMap();
            CreateMap<UserDomainModel, UserViewModel>().ReverseMap();
        }
    }
}
