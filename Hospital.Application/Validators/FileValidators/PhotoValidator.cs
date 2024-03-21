using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Validators.FileValidators
{
    public class PhotoValidator : AbstractValidator<IFormFile>
    {
        private readonly string[] _allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public PhotoValidator()
        {
            RuleFor(file => file.Length).NotEmpty().WithMessage("Dosya boş olamaz")
                .LessThanOrEqualTo(_maxFileSize).WithMessage("Dosya boyutu 5MB'dan küçük olmalıdır.");

            RuleFor(file => file.FileName).NotEmpty().WithMessage("Dosya adı boş olamaz")
                .Must(HaveAllowedExtension).WithMessage("Geçersiz dosya uzantısı");
        }

        private bool HaveAllowedExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return _allowedExtensions.Contains(extension);
        }
    }
}
