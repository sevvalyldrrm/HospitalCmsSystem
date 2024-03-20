using HospitalCmsSystem.Application.CQRS.Commands.LoginCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AuthHandlers
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandDto>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IEmailService _emailSender;
		private readonly IUrlHelperFactory _urlHelperFactory;
		private readonly IActionContextAccessor _actionContextAccessor;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public RegisterCommandHandler(UserManager<AppUser> userManager, IEmailService emailSender, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor,  IHttpContextAccessor httpContextAccessor)
		{
			_userManager = userManager;
			_emailSender = emailSender;
			_urlHelperFactory = urlHelperFactory;
			_actionContextAccessor = actionContextAccessor;
			_httpContextAccessor = httpContextAccessor;
			
		}

		public async Task<RegisterCommandDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			if (request.Password != request.ConfirmPassword)
			{
				return new RegisterCommandDto
				{
					Success = false,
					Errors = new List<string> { "Password and confirm password do not match." }
				};
			}

			var user = new AppUser
			{
				UserName = request.Email,
				Email = request.Email
			};

			var result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
			{
				return new RegisterCommandDto
				{
					Success = false,
					Errors = result.Errors.Select(e => e.Description).ToList()
				};
			}

			var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
			var scheme = _httpContextAccessor.HttpContext.Request.Scheme;

			var confirmationLink = urlHelper.Action("ConfirmEmail", "Auth", new { userId = user.Id, token = token }, scheme);
			await _emailSender.SendEmailAsync(user.Email, "Please confirm your email", $"Please confirm your account by <a href=\"{confirmationLink}\">clicking here</a>.");

			return new RegisterCommandDto
			{
				Success = true,
				Message = "User registered successfully. Please check your email to confirm your account."
			};
		}
	}
}
