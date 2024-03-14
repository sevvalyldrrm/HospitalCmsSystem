using HospitalCmsSystem.Application.CQRS.Commands.DoctorCommands;
using HospitalCmsSystem.Application.CQRS.Queries.DoctorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> DoctorList()
        {
            var values = await _mediator.Send(new GetDoctorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var value = await _mediator.Send(new GetDoctorByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Doctor başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDoctor(int id)
        {
            await _mediator.Send(new RemoveDoctorCommand(id));
            return Ok("Doctor başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Doctor başarıyla güncellendi");
        }
    }
}
