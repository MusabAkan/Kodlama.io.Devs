using Application.Features.CodingSkills.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.CodingSkills.Queries.GetListCodingSkill
{
    public class GetListCodingSkillQuery : IRequest<CodingSkillListModel>
    {
        public PageRequest PageRequest { get; set; }

        class GetListCodingSkillQueryHandler : IRequestHandler<GetListCodingSkillQuery, CodingSkillListModel>
        {
            private readonly IMapper _mapper;
            private readonly ICodingSkillRepository _codingSkillRepository;

            public GetListCodingSkillQueryHandler(IMapper mapper, ICodingSkillRepository codingSkillRepository)
            {
                _mapper = mapper;
                _codingSkillRepository = codingSkillRepository;
            }

            public async Task<CodingSkillListModel> Handle(GetListCodingSkillQuery request, CancellationToken cancellationToken)
            {
                var all = await _codingSkillRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                var mapped = _mapper.Map<CodingSkillListModel>(all);

                return mapped;
            }
        }
    }
}
