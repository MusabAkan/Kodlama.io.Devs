using Application.Features.CodingSkills.Commands.CreateCodingSkill;
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
    }
}
