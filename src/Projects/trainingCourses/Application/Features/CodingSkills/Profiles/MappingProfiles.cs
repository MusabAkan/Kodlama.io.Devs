using Application.Features.CodingSkills.Commands.CreateCodingSkill;
using Application.Features.CodingSkills.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Application.Features.CodingSkills.Profiles
{
    
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CodingSkill, CodingSkillCommand>().ReverseMap();  
            CreateMap<CreatedCodingSkillDto, CodingSkill>().ReverseMap();
        }
    }
}
