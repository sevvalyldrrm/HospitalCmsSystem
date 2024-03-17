using HospitalCmsSystem.Application.CQRS.Commands.DepartmentCommands;
using HospitalCmsSystem.Application.CQRS.Queries.DepartmentQueries;
using HospitalCmsSystem.Application.CQRS.Queries.DoctorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var values = await _mediator.Send(new GetDepartmentQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var value = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Department başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDepartment(int id)
        {
            await _mediator.Send(new RemoveDepartmentCommand(id));
            return Ok("Department başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Department başarıyla güncellendi");
        }

        [HttpGet("GetDepartmentWithDetails/{id}")]
        public async Task<IActionResult> GetDepartmentWithDetails(int id)
        {
            var value = await _mediator.Send(new GetDepartmentWithDetailsByIdQuery(id));
            return Ok(value);
        }
    }
}
