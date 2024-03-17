using FluentValidation;
using HospitalCmsSystem.Application.CQRS.Commands.AdminCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Validators.AdminValidators
{
    public class UpdateAdminValidator:AbstractValidator<UpdateAdminCommand>
    {
        public UpdateAdminValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim boş geçilemez").MinimumLength(2).WithMessage("İsim çok kısa").MaximumLength(50).WithMessage("İsim çok uzun");
            RuleFor(x=>x.GitHubAcc).NotEmpty().WithMessage("Github Hesabı boş geçilemez").MinimumLength(2).WithMessage("Github Hesabı çok kısa").MaximumLength(50).WithMessage("Github Hesabı çok uzun"); ;
        }
    }
}
