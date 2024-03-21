using HospitalCmsSystem.Application.CQRS.Results.FileUploadResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.FileUploadCommands
{
    public class UploadPhotoCommand : IRequest<PhotoResultDto>
    {
        public IFormFile File { get; set; }
    }
}
