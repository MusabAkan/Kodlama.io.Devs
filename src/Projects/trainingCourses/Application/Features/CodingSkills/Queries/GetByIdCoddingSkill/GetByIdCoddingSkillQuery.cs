using Application.Features.CodingSkills.Dtos;
using Application.Features.CodingSkills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CodingSkills.Queries.GetByIdCoddingSkill
{
    public class GetByIdCoddingSkillQuery : IRequest<CodingSkillGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdCoddingSkillQueryHandler : IRequestHandler<GetByIdCoddingSkillQuery, CodingSkillGetByIdDto>
        {
            private readonly ICodingSkillRepository _codingSkillRepository;
            private readonly IMapper _mapper;
            private readonly CodingSkillBusinessRules _codingSkillBusinessRules;

            public GetByIdCoddingSkillQueryHandler(ICodingSkillRepository codingSkillRepository, IMapper mapper, CodingSkillBusinessRules codingSkillBusinessRules)
            {
                _codingSkillRepository = codingSkillRepository;
                _mapper = mapper;
                _codingSkillBusinessRules = codingSkillBusinessRules;
            }

            public async Task<CodingSkillGetByIdDto> Handle(GetByIdCoddingSkillQuery request, CancellationToken cancellationToken)
            {

                var exists = await _codingSkillRepository.GetAsync(b => b.Id == request.Id);

                _codingSkillBusinessRules.CodingSkillShouldExistWhenRequested(exists);

                var dto = _mapper.Map<CodingSkillGetByIdDto>(exists);

                return dto;
            }
        }
    }
}
