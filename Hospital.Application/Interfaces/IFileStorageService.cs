using HospitalCmsSystem.Application.CQRS.Results.FileUploadResults;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<FileStorageResult> SaveFileAsync(IFormFile file);
    }
}
