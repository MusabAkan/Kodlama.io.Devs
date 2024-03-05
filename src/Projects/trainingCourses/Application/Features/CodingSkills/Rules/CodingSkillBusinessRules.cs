using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

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
            if (result.Items.Any()) throw new BusinessException("Coding skill name exists");
        }
        public void CodingSkillShouldExistWhenRequested(CodingSkill? exists)
        {
            if (exists == null) throw new BusinessException("Requested coding skill does not exist");
        }
    }
}
