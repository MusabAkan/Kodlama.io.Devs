using Application.Features.CodingSkills.Dtos;
using Application.Features.CodingSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CodingSkills.Commands.RemoveCodingSkill
{
    public class RemoveCodingSkillCommand : IRequest<CodingSkillRemoveDto>
    {
        public int Id { get; set; }
        public class RemoveCodingSkillCommandHandler : IRequestHandler<RemoveCodingSkillCommand, CodingSkillRemoveDto>
        {
            private readonly ICodingSkillRepository _codingSkillRepository;
            private readonly IMapper _mapper;
            private readonly CodingSkillBusinessRules _codingSkillBusinessRules;

            public RemoveCodingSkillCommandHandler(CodingSkillBusinessRules codingSkillBusinessRules, IMapper mapper, ICodingSkillRepository codingSkillRepository)
            {
                _codingSkillBusinessRules = codingSkillBusinessRules;
                _mapper = mapper;
                _codingSkillRepository = codingSkillRepository;
            }

            public async Task<CodingSkillRemoveDto> Handle(RemoveCodingSkillCommand request, CancellationToken cancellationToken)
            {
                var exists = await _codingSkillRepository.GetAsync(b => b.Id == request.Id);

                _codingSkillBusinessRules.CodingSkillShouldExistWhenRequested(exists);
                await _codingSkillRepository.DeleteAsync(exists);  
                
                var mapped = _mapper.Map<CodingSkillRemoveDto>(exists);

                return mapped;
            }
        }
    }
}
