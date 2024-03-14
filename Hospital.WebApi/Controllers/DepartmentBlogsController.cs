using HospitalCmsSystem.Application.CQRS.Commands.DepartmentBlogCommands;
using HospitalCmsSystem.Application.CQRS.Queries.DepartmentBlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentBlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentBlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentBlogList()
        {
            var values = await _mediator.Send(new GetDepartmentBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentBlog(int id)
        {
            var value = await _mediator.Send(new GetDepartmentBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartmentBlog(CreateDepartmentBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("DepartmentBlog başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDepartmentBlog(int id)
        {
            await _mediator.Send(new RemoveDepartmentBlogCommand(id));
            return Ok("DepartmentBlog başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartmentBlog(UpdateDepartmentBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("DepartmentBlog başarıyla güncellendi");
        }
    }
}
