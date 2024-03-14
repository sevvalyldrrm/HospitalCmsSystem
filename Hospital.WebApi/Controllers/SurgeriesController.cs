using HospitalCmsSystem.Application.CQRS.Commands.SurgeryCommands;
using HospitalCmsSystem.Application.CQRS.Queries.SurgeryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SurgeriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SurgeryList()
        {
            var values = await _mediator.Send(new GetSurgeryQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurgery(int id)
        {
            var value = await _mediator.Send(new GetSurgeryByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSurgery(CreateSurgeryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Surgery başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSurgery(int id)
        {
            await _mediator.Send(new RemoveSurgeryCommand(id));
            return Ok("Surgery başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSurgery(UpdateSurgeryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Surgery başarıyla güncellendi");
        }
    }
}
