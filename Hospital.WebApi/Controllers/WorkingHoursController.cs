using HospitalCmsSystem.Application.CQRS.Commands.WorkingHourCommands;
using HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WorkingHoursController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> WorkingHourList()
        {
            var values = await _mediator.Send(new GetWorkingHourQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkingHour(int id)
        {
            var value = await _mediator.Send(new GetWorkingHourByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWorkingHour(CreateWorkingHourCommand command)
        {
            await _mediator.Send(command);
            return Ok("WorkingHour başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveWorkingHour(int id)
        {
            await _mediator.Send(new RemoveWorkingHourCommand(id));
            return Ok("WorkingHour başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWorkingHour(UpdateWorkingHourCommand command)
        {
            await _mediator.Send(command);
            return Ok("WorkingHour başarıyla güncellendi");
        }
    }
}
