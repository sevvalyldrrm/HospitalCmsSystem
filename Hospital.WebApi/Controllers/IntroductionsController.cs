using HospitalCmsSystem.Application.CQRS.Commands.IntroductionCommands;
using HospitalCmsSystem.Application.CQRS.Queries.IntroductionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroductionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IntroductionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> IntroductionList()
        {
            var values = await _mediator.Send(new GetIntroductionQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIntroduction(int id)
        {
            var value = await _mediator.Send(new GetIntroductionByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateIntroduction(CreateIntroductionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Introduction başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveIntroduction(int id)
        {
            await _mediator.Send(new RemoveIntroductionCommand(id));
            return Ok("Introduction başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateIntroduction(UpdateIntroductionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Introduction başarıyla güncellendi");
        }
    }
}
