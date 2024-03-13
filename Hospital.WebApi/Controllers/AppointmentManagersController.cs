using HospitalCmsSystem.Application.CQRS.Commands.AppointmentManagerCommands;
using HospitalCmsSystem.Application.CQRS.Queries.AppointmentManagerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentManagersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentManagersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AppointmentManagerList()
        {
            var values = await _mediator.Send(new GetAppointmentManagerQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentManager(int id)
        {
            var value = await _mediator.Send(new GetAppointmentManagerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointmentManager(CreateAppointmentManagerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Randevu yönetimi başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAppointmentManager(int id)
        {
            await _mediator.Send(new RemoveAppointmentManagerCommand(id));
            return Ok("Randevu yönetimi başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppointmentManager(UpdateAppointmentManagerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Randevu yönetimi başarıyla güncellendi");
        }
    }
}
