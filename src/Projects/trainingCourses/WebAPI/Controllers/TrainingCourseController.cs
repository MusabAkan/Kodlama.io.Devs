using Application.Features.CodingSkills.Commands.CreateCodingSkill;
using Application.Features.CodingSkills.Queries.GetListCodingSkill;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCourseController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CodingSkillCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetListCodingSkillQuery() { PageRequest = pageRequest };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
