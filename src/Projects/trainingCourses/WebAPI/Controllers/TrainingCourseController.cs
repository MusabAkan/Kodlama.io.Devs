using Application.Features.CodingSkills.Commands.CreateCodingSkill;
using Application.Features.CodingSkills.Commands.RemoveCodingSkill;
using Application.Features.CodingSkills.Commands.UpdateCodingSkill;
using Application.Features.CodingSkills.Queries.GetByIdCoddingSkill;
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
        public async Task<IActionResult> Add([FromBody] CreateCodingSkillCommand command)
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
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCoddingSkillQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCodingSkillCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveCodingSkillCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
