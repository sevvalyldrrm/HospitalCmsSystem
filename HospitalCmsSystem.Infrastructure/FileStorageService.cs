using HospitalCmsSystem.Application.CQRS.Results.FileUploadResults;
using HospitalCmsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO; // Eğer eksikse ekleyin
using System.Threading.Tasks;
using System.Web; // Eğer eksikse ekleyin

namespace HospitalCmsSystem.Infrastructure
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _uploadsFolderPath;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _uploadsFolderPath = Path.Combine(env.ContentRootPath, "Uploads");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<FileStorageResult> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is null or empty.");
            }

            if (!Directory.Exists(_uploadsFolderPath))
                Directory.CreateDirectory(_uploadsFolderPath);

            var fileName = GenerateUniqueFileName(file.FileName);
            var filePath = Path.Combine(_uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host.Value}";
            var fileUrl = $"{baseUrl}/uploads/{fileName}"; // URL kodlaması yapılmış ismi kullan

            return new FileStorageResult { FileName = fileName, FilePath = fileUrl };
        }

        private string GenerateUniqueFileName(string originalFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(originalFileName)
                               .Replace(" ", "_") // Boşlukları ve özel karakterleri alt çizgi ile değiştir
                               .Replace("&", "_")
                               // Burada gerekirse daha fazla karakter değişikliği yapabilirsiniz.
                               .ToLower(); // İsmi küçük harfe çevir
            var extension = Path.GetExtension(originalFileName).ToLower(); // Uzantıyı küçük harfe çevir
            var uniqueName = $"{fileName}_{Guid.NewGuid()}{extension}";

            return uniqueName; // URL dostu bir ad oluşturun (URL kodlaması yapılmadan)
        }
    }
}