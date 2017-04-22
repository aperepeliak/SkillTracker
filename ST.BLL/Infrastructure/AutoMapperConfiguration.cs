using AutoMapper;
using ST.BLL.DTOs;
using ST.DAL.Models;
using System.Linq;

namespace ST.BLL.Infrastructure
{
    public class MappingDtoProfile : Profile
    {
        public MappingDtoProfile()
        {
            Mapper.CreateMap<SkillRating, SkillRatingDto>()
                .ForMember(dto => dto.CategoryName, m => m.MapFrom(sr => sr.Skill.Category.Name))
                .ForMember(dto => dto.SkillName, m => m.MapFrom(sr => sr.Skill.Name));

            Mapper.CreateMap<SkillRatingDto, SkillRating>();

            Mapper.CreateMap<Developer, DeveloperDto>()
                .ForMember(dto => dto.Email, m => m.MapFrom(d => d.User.Email))
                .ForMember(dto => dto.FirstName, m => m.MapFrom(d => d.User.FirstName))
                .ForMember(dto => dto.LastName, m => m.MapFrom(d => d.User.LastName))
                .ForMember(dto => dto.SkillRatings,
                    m => m.MapFrom(d => d.SkillRatings
                                        .Select(Mapper.Map<SkillRating, SkillRatingDto>)
                                        .OrderBy(s => s.CategoryName)
                                        .ThenByDescending(s => s.Rating)
                                        .GroupBy(s => s.CategoryName)
                                        .ToDictionary(g => g.Key, g => g.ToList())
                    ));
        }
    }
}
