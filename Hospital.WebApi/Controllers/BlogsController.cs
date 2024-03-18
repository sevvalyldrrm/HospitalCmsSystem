using HospitalCmsSystem.Application.CQRS.Commands.BlogCommands;
using HospitalCmsSystem.Application.CQRS.Queries.BlogQueries;
using HospitalCmsSystem.Application.CQRS.Queries.DepartmentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla güncellendi");
        }

        [HttpGet("GetBlogWithIncludeQuery")]
        public async Task<IActionResult> GetBlogWithInclude()
        {
            var value = await _mediator.Send(new GetBlogWithIncludeQuery());
            return Ok(value);

        }
    }
}
