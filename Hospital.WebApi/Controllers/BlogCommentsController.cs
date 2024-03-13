using HospitalCmsSystem.Application.CQRS.Commands.BlogCommentCommands;
using HospitalCmsSystem.Application.CQRS.Queries.BlogCommentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BlogCommentList()
        {
            var values = await _mediator.Send(new GetBlogCommentQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogComment(int id)
        {
            var value = await _mediator.Send(new GetBlogCommentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogComment(CreateBlogCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog yorumu başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlogComment(int id)
        {
            await _mediator.Send(new RemoveBlogCommentCommand(id));
            return Ok("Blog yorumu başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlogComment(UpdateBlogCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog yorumu başarıyla güncellendi");
        }
    }
}
