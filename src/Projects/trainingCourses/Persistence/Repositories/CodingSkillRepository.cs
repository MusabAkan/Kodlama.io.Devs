using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
namespace Persistence.Repositories
{
    public class CodingSkillRepository : EfRepositoryBase<CodingSkill, BaseDbContext>, ICodingSkillRepository
    {
        public CodingSkillRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
