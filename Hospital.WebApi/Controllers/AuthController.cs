using HospitalCmsSystem.Application.CQRS.Commands.AuthCommands;
using HospitalCmsSystem.Application.CQRS.Commands.LoginCommands;
using HospitalCmsSystem.Application.CQRS.Queries.AdminQueries;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HospitalCmsSystem.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginCommand loginCommand)
		{
			var result = await _mediator.Send(loginCommand);

			if (result.Success)
			{
				return Ok(result);
			}

			return Unauthorized();
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register(RegisterCommand registerCommand)
		{
			var result = await _mediator.Send(registerCommand);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result.Errors);

		}

		[HttpGet("ConfirmEmail")]
		public async Task<IActionResult> ConfirmEmail(int userId, string token)
		{
			var command = new ConfirmEmailCommand { UserId = userId, Token = token };
			var result = await _mediator.Send(command);

			if (!result.Success)
			{
				return BadRequest(result.Errors);
			}

			return Ok(result.Message);
		}

		[HttpPost("Logout")]
		public async Task<IActionResult> Logout()
		{
			var command = new LogoutCommand();

			var result = await _mediator.Send(command);
			if (!result.Success)
			{
				return BadRequest(result.Message);
			}

			return Ok(result.Message);
		}

		[HttpPost("PasswordResetRequest")]
		public async Task<IActionResult> PasswordResetRequest(PasswordResetRequestCommand passwordResetRequestCommand)
		{
			var result = await _mediator.Send(passwordResetRequestCommand);

			if (result.Success)
			{
				return Ok(result.Message);
			}

			return BadRequest(result.Errors);
		}

		[HttpPost("ResetPassword")]
		public async Task<IActionResult> ResetPassword(ResetPasswordCommand resetPasswordCommand)
		{
			var result = await _mediator.Send(resetPasswordCommand);

			if (result.Success)
			{
				return Ok(result.Message);
			}

			return BadRequest(result.Errors);
		}
	}
}
