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
	public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutCommandResult>
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LogoutCommandHandler(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		public async Task<LogoutCommandResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
		{
			await _signInManager.SignOutAsync();
			return new LogoutCommandResult
			{
				Success = true,
				Message = "Logged out successfully."
			};
		}
	}
}
