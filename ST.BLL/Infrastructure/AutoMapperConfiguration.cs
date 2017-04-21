using AutoMapper;
using ST.BLL.DTOs;
using ST.DAL.Models;

namespace ST.BLL.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingDtoProfile>();
            });
        }
    }

    public class MappingDtoProfile : Profile
    {
        public MappingDtoProfile()
        {
            Mapper.CreateMap<SkillRating, SkillRatingDto>();
            //Mapper.CreateMap<Developer, DeveloperDto>()
            //    .ForMember(dto => dto.SkillRatings, m => m.MapFrom())
        }      
    }
}
