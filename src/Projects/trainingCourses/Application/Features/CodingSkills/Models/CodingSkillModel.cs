using Application.Features.CodingSkills.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.CodingSkills.Models
{
    public class CodingSkillListModel : BasePageableModel
    {
        public IList<CodingSkillListDto> Items { get; set; }
    }

}
