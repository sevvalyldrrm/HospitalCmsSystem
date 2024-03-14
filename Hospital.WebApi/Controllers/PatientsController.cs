using HospitalCmsSystem.Application.CQRS.Commands.PatientCommands;
using HospitalCmsSystem.Application.CQRS.Queries.PatientQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> PatientList()
        {
            var values = await _mediator.Send(new GetPatientQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var value = await _mediator.Send(new GetPatientByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
        {
            await _mediator.Send(command);
            return Ok("Patient başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePatient(int id)
        {
            await _mediator.Send(new RemovePatientCommand(id));
            return Ok("Patient başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command)
        {
            await _mediator.Send(command);
            return Ok("Patient başarıyla güncellendi");
        }
    }
}
