using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.CodingSkills.Rules
{
    public class CodingSkillBusinessRules
    {
        private readonly ICodingSkillRepository _codingSkillRepository;
        public CodingSkillBusinessRules(ICodingSkillRepository codingSkillRepository)
        {
            _codingSkillRepository = codingSkillRepository;
        }
        public async Task CodingSkillNameCannotBeDuplicatedWhenNameIsAdded(string name)
        {
            var result = await _codingSkillRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("CodingSkill name exists");
        }
    }
}
