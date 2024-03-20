using HospitalCmsSystem.Application.CQRS.Commands.LoginCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.LoginHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResultDto>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ITokenService _tokenService;

		public LoginCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_tokenService = tokenService;
		}

		public async Task<AuthenticationResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
			{
				return new AuthenticationResultDto
				{
					Success = false,
					Errors = new [] {"Invalid username or pass"}
				};
			}

			var token = await _tokenService.GetToken(user);
			return new AuthenticationResultDto { Success = true, Token = token };	
		}
	}
}
