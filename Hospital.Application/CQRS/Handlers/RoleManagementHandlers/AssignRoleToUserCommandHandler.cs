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
    public class AssignRoleToUserCommandHandler : IRequestHandler<AssignRoleToUserCommand, AssignRoleToUserResultDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AssignRoleToUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AssignRoleToUserResultDto> Handle(AssignRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return new AssignRoleToUserResultDto { Success = false, Errors = new[] { $"User with ID {request.UserId} not found." } };
            }

            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (role == null)
            {
                return new AssignRoleToUserResultDto { Success = false, Errors = new[] { $"Role with ID {request.RoleId} does not exist." } };
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Contains(role.Name))
            {
                return new AssignRoleToUserResultDto { Success = false, Errors = new[] { $"User {user.UserName} is already in role {role.Name}." } };
            }

            var addResult = await _userManager.AddToRoleAsync(user, role.Name);
            if (!addResult.Succeeded)
            {
                return new AssignRoleToUserResultDto { Success = false, Errors = addResult.Errors.Select(e => e.Description) };
            }

            return new AssignRoleToUserResultDto { Success = true };
        }
    }
}
