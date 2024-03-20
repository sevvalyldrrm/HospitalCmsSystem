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
    public class RemoveRoleFromUserCommandHandler : IRequestHandler<RemoveRoleFromUserCommand, RemoveRoleFromUserResultDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RemoveRoleFromUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<RemoveRoleFromUserResultDto> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return new RemoveRoleFromUserResultDto { Success = false, Errors = new[] { $"User with ID {request.UserId} not found." } };
            }

            var roleExist = await _roleManager.RoleExistsAsync(request.Role);
            if (!roleExist)
            {
                return new RemoveRoleFromUserResultDto { Success = false, Errors = new[] { $"Role {request.Role} does not exist." } };
            }

            var isInRole = await _userManager.IsInRoleAsync(user, request.Role);
            if (!isInRole)
            {
                return new RemoveRoleFromUserResultDto { Success = false, Errors = new[] { $"User {user.UserName} is not in role {request.Role}." } };
            }

            var result = await _userManager.RemoveFromRoleAsync(user, request.Role);
            if (!result.Succeeded)
            {
                return new RemoveRoleFromUserResultDto { Success = false, Errors = result.Errors.Select(e => e.Description) };
            }

            return new RemoveRoleFromUserResultDto { Success = true };
        }
    }
}
