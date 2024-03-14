using HospitalCmsSystem.Application.CQRS.Commands.DepartmentDetailCommands;
using HospitalCmsSystem.Application.CQRS.Queries.DepartmentDetailQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentDetailList()
        {
            var values = await _mediator.Send(new GetDepartmentDetailQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentDetail(int id)
        {
            var value = await _mediator.Send(new GetDepartmentDetailByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartmentDetail(CreateDepartmentDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok("DepartmentDetail başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDepartmentDetail(int id)
        {
            await _mediator.Send(new RemoveDepartmentDetailCommand(id));
            return Ok("DepartmentDetail başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartmentDetail(UpdateDepartmentDetailCommand command)
        {
            await _mediator.Send(command);
            return Ok("DepartmentDetail başarıyla güncellendi");
        }
    }
}
