using HospitalCmsSystem.Application.CQRS.Commands.DoctorPatientCommands;
using HospitalCmsSystem.Application.CQRS.Queries.DoctorPatientQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorPatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorPatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> DoctorPatientList()
        {
            var values = await _mediator.Send(new GetDoctorPatientQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorPatient(int id)
        {
            var value = await _mediator.Send(new GetDoctorPatientByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctorPatient(CreateDoctorPatientCommand command)
        {
            await _mediator.Send(command);
            return Ok("DoctorPatient başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDoctorPatient(int id)
        {
            await _mediator.Send(new RemoveDoctorPatientCommand(id));
            return Ok("DoctorPatient başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctorPatient(UpdateDoctorPatientCommand command)
        {
            await _mediator.Send(command);
            return Ok("DoctorPatient başarıyla güncellendi");
        }
    }
}
