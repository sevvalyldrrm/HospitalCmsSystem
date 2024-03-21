using HospitalCmsSystem.Application.CQRS.Commands.FileUploadCommands;
using HospitalCmsSystem.Application.CQRS.Results.FileUploadResults;
using HospitalCmsSystem.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.FileUploadHandlers
{
    public class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommand, PhotoResultDto>
    {
        private readonly IFileStorageService _fileStorageService;

        public UploadPhotoCommandHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public async Task<PhotoResultDto> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
        {
            // Dosya servisini kullanarak dosyayı kaydet
            var fileResult = await _fileStorageService.SaveFileAsync(request.File);

            // Kaydedilen dosyanın adını ve yolunu döndür
            return new PhotoResultDto
            {
                FileName = fileResult.FileName,
                FilePath = fileResult.FilePath
            };
        }
    }
}
