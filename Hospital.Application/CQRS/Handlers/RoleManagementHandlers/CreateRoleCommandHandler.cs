using HospitalCmsSystem.Application.CQRS.Commands.RoleManagementCommands;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.RoleManagementHandlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleResultDto>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<CreateRoleResultDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RoleName))
            {
                return new CreateRoleResultDto { Success = false, Errors = new[] { "Role name is required." } };
            }

            var roleExist = await _roleManager.RoleExistsAsync(request.RoleName);
            if (roleExist)
            {
                return new CreateRoleResultDto { Success = false, Errors = new[] { "Role already exists." } };
            }

            var result = await _roleManager.CreateAsync(new AppRole
            {
                Name = request.RoleName
            });
            if (result.Succeeded)
            {
                return new CreateRoleResultDto { Success = true };
            }

            return new CreateRoleResultDto { Success = false, Errors = result.Errors.Select(e => e.Description) };
        }
    }
}
