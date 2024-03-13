using HospitalCmsSystem.Application.CQRS.Commands.BlogImageCommands;
using HospitalCmsSystem.Application.CQRS.Queries.BlogImageQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BlogImageList()
        {
            var values = await _mediator.Send(new GetBlogImageQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogImage(int id)
        {
            var value = await _mediator.Send(new GetBlogImageByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogImage(CreateBlogImageCommand command)
        {
            await _mediator.Send(command);
            return Ok("BlogImage başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlogImage(int id)
        {
            await _mediator.Send(new RemoveBlogImageCommand(id));
            return Ok("BlogImage başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlogImage(UpdateBlogImageCommand command)
        {
            await _mediator.Send(command);
            return Ok("BlogImage başarıyla güncellendi");
        }
    }
}
