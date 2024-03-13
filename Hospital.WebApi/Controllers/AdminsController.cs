using HospitalCmsSystem.Application.CQRS.Commands.AdminCommands;
using HospitalCmsSystem.Application.CQRS.Queries.AdminQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AdminList()
        {
            var values = await _mediator.Send(new GetAdminQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var value = await _mediator.Send(new GetAdminByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminCommand command)
        {
            await _mediator.Send(command);
            return Ok("Admin başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAdmin(int id)
        {
            await _mediator.Send(new RemoveAdminCommand(id));
            return Ok("Admin başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminCommand command)
        {
            await _mediator.Send(command);
            return Ok("Admin başarıyla güncellendi");
        }
    }
}
