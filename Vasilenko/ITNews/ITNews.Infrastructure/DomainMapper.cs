using ITNews.Data.Contracts.Entities;
using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Infrastructure
{
    public class DomainMapper: AutoMapper.Profile
    {
        public DomainMapper()
        {
            CreateMap<Post, PostDomainModel>().ReverseMap();
            CreateMap<Category, CategoryDomainModel>().ReverseMap();
            CreateMap<Comment, CommentDomainModel>().ReverseMap();
            CreateMap<Like, LikeDomainModel>().ReverseMap();
            CreateMap<PostTag, PostTagDomainModel>().ReverseMap();
            CreateMap<PostRating, PostRatingDomainModel>().ReverseMap();
            CreateMap<Profile, ProfileDomainModel>().ReverseMap();
            CreateMap<Tag, TagDomainModel>().ReverseMap();
            CreateMap<ApplicationUser, UserDomainModel>()
                .ForMember(x => x.Id, c => c.MapFrom(d => d.Id)).ReverseMap()
                .ForMember(x => x.Blocked, c => c.MapFrom(d => d.Blocked)).ReverseMap()
                .ForMember(x => x.Email, c => c.MapFrom(d => d.Email)).ReverseMap()
                .ForMember (x=> x.UserName, c=> c.MapFrom (d => d.UserName)).ReverseMap()
                .ForMember(x => x.EmailComfirmed, c => c.MapFrom(d => d.EmailConfirmed)).ReverseMap()
                .ForMember(x => x.ProfileId, c => c.MapFrom(d => d.ProfileId)).ReverseMap();
            CreateMap<List<ApplicationUser>, List<UserDomainModel>>().ReverseMap();
        }

    }
}
