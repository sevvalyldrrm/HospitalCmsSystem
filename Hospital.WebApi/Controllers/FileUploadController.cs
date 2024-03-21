using HospitalCmsSystem.Application.CQRS.Commands.FileUploadCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileUploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload-photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            // MediatR kullanarak command gönder
            var command = new UploadPhotoCommand { File = file };
            var result = await _mediator.Send(command);

            // İşlem sonucunu döndür
            return Ok(result);
        }
    }
}

