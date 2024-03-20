using FluentValidation;
using HospitalCmsSystem.Dto.RoleManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Validators.RoleManagementValidators
{
    public class UserRoleUpdateModelValidator : AbstractValidator<UserRoleUpdateModel>
    {
        public UserRoleUpdateModelValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Invalid user ID.");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role name is required.");
        }
    }
}
