using Application.Features.CodingSkills.Commands.CreateCodingSkill;
using Application.Features.CodingSkills.Commands.UpdateCodingSkill;
using Application.Features.CodingSkills.Dtos;
using Application.Features.CodingSkills.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
namespace Application.Features.CodingSkills.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CodingSkill, CreateCodingSkillCommand>().ReverseMap();
            CreateMap<CreatedCodingSkillDto, CodingSkill>().ReverseMap();

            CreateMap<CodingSkillListModel, IPaginate<CodingSkill>>().ReverseMap();
            CreateMap<CodingSkill, CodingSkillListDto>();

            CreateMap<CodingSkillGetByIdDto, CodingSkill>().ReverseMap();
            CreateMap<CodingSkillRemoveDto, CodingSkill>().ReverseMap();

            CreateMap<UpdateCodingSkillCommand, CodingSkill>().ReverseMap();
            CreateMap<CodingSkillUpdateDto, CodingSkill>().ReverseMap();
            
        }
    }
}
