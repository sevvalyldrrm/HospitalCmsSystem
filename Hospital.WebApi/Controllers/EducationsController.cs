using HospitalCmsSystem.Application.CQRS.Commands.EducationCommands;
using HospitalCmsSystem.Application.CQRS.Queries.EducationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EducationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> EducationList()
        {
            var values = await _mediator.Send(new GetEducationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducation(int id)
        {
            var value = await _mediator.Send(new GetEducationByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEducation(CreateEducationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Education başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveEducation(int id)
        {
            await _mediator.Send(new RemoveEducationCommand(id));
            return Ok("Education başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEducation(UpdateEducationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Education başarıyla güncellendi");
        }
    }
}
