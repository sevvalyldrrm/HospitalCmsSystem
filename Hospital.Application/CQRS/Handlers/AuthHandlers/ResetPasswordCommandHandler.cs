using HospitalCmsSystem.Application.CQRS.Commands.AuthCommands;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AuthHandlers
{
	public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordCommandDto>
	{
		private readonly UserManager<AppUser> _userManager;

		public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<ResetPasswordCommandDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
		{

			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				return new ResetPasswordCommandDto
				{
					Success = false,
					Errors = new List<string> { "User not found." }
				};
			}

			var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
			if (!result.Succeeded)
			{
				return new ResetPasswordCommandDto
				{
					Success = false,
					Errors = result.Errors.Select(e => e.Description).ToList()
				};
			}

			return new ResetPasswordCommandDto
			{
				Success = true,
				Message = "Password reset successfully."
			};
		}
	}
}
