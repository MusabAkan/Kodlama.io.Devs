using Application.Features.CodingSkills.Dtos;
using Application.Features.CodingSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CodingSkills.Commands.UpdateCodingSkill
{
    public class UpdateCodingSkillCommand : IRequest<CodingSkillUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateCodingSkillCommandHandler : IRequestHandler<UpdateCodingSkillCommand, CodingSkillUpdateDto>
        {
            private readonly ICodingSkillRepository _codingSkillRepository;
            private readonly IMapper _mapper;
            private readonly CodingSkillBusinessRules _codingSkillBusinessRules;

            public UpdateCodingSkillCommandHandler(CodingSkillBusinessRules codingSkillBusinessRules, IMapper mapper, ICodingSkillRepository codingSkillRepository)
            {
                _codingSkillBusinessRules = codingSkillBusinessRules;
                _mapper = mapper;
                _codingSkillRepository = codingSkillRepository;
            }
            public async Task<CodingSkillUpdateDto> Handle(UpdateCodingSkillCommand request, CancellationToken cancellationToken)
            {
                var exists = await _codingSkillRepository.GetAsync(b => b.Id == request.Id && b.Name != request.Name);

                _codingSkillBusinessRules.CodingSkillShouldExistWhenRequested(exists);

                var mapped = _mapper.Map(request, exists);//Id aynı olmasından kayanklı birleştirme işlemi yapıyorum
                await _codingSkillRepository.UpdateAsync(mapped);

                var mappedDto = _mapper.Map<CodingSkillUpdateDto>(mapped);
                return mappedDto;
            }
        }
    }
}
