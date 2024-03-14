using HospitalCmsSystem.Application.CQRS.Commands.SurgeryDoctorCommands;
using HospitalCmsSystem.Application.CQRS.Queries.SurgeryDoctorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeryDoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SurgeryDoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SurgeryDoctorList()
        {
            var values = await _mediator.Send(new GetSurgeryDoctorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurgeryDoctor(int id)
        {
            var value = await _mediator.Send(new GetSurgeryDoctorByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSurgeryDoctor(CreateSurgeryDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok("SurgeryDoctor başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSurgeryDoctor(int id)
        {
            await _mediator.Send(new RemoveSurgeryDoctorCommand(id));
            return Ok("SurgeryDoctor başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSurgeryDoctor(UpdateSurgeryDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok("SurgeryDoctor başarıyla güncellendi");
        }
    }
}
