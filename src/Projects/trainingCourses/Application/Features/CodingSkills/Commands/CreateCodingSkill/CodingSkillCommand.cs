using Application.Features.CodingSkills.Dtos;
using Application.Features.CodingSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CodingSkills.Commands.CreateCodingSkill
{
    public class CodingSkillCommand : IRequest<CreatedCodingSkillDto>
    {
        public string Name { get; set; }
        public class CodingSkillCommandHandler : IRequestHandler<CodingSkillCommand, CreatedCodingSkillDto>
        {
            private readonly IMapper _mapper;
            private readonly ICodingSkillRepository _codingSkillRepository;
            private readonly CodingSkillBusinessRules _codingSkillBusiness;
            public CodingSkillCommandHandler(IMapper mapper, ICodingSkillRepository codingSkillRepository, CodingSkillBusinessRules codingSkillBusiness)
            {
                _mapper = mapper;
                _codingSkillRepository = codingSkillRepository;
                _codingSkillBusiness = codingSkillBusiness;
            }

            public async Task<CreatedCodingSkillDto> Handle(CodingSkillCommand request, CancellationToken cancellationToken)
            {
                await _codingSkillBusiness.CodingSkillNameCannotBeDuplicatedWhenNameIsAdded(request.Name);

                var mapped = _mapper.Map<CodingSkill>(request);
                var created = await _codingSkillRepository.AddAsync(mapped);
                var dto = _mapper.Map<CreatedCodingSkillDto>(created);

                return dto;

            }
        }
    }
}
