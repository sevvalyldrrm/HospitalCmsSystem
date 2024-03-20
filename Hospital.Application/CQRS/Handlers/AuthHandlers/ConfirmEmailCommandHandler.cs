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
	public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ConfirmEmailCommandResult>
	{
		private readonly UserManager<AppUser> _userManager;

		public ConfirmEmailCommandHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<ConfirmEmailCommandResult> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
		{
			if (request.UserId == null || request.Token == null)
			{
				return new ConfirmEmailCommandResult
				{
					Success = false,
					Message = "User ID and Token are required."
				};
			}

			var user = await _userManager.FindByIdAsync(request.UserId.ToString());
			if (user == null)
			{
				return new ConfirmEmailCommandResult
				{
					Success = false,
					Message = $"Unable to load user with ID '{request.UserId}'."
				};
			}

			var result = await _userManager.ConfirmEmailAsync(user, request.Token);
			if (!result.Succeeded)
			{
				return new ConfirmEmailCommandResult
				{
					Success = false,
					Errors = result.Errors.Select(e => e.Description).ToList()
				};
			}

			return new ConfirmEmailCommandResult
			{
				Success = true,
				Message = "Email confirmed successfully."
			};
		}
	}
}
