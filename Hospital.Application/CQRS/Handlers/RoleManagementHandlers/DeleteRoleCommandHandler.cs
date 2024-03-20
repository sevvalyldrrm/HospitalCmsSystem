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
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleResultDto>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public DeleteRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<DeleteRoleResultDto> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                return new DeleteRoleResultDto { Success = false, Errors = new[] { $"Role {request.RoleName} not found." } };
            }

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return new DeleteRoleResultDto { Success = false, Errors = result.Errors.Select(e => e.Description) };
            }

            return new DeleteRoleResultDto { Success = true };
        }
    }
}
