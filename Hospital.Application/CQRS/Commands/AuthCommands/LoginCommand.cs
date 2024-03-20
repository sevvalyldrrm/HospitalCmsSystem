using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.LoginCommands
{
	public class LoginCommand : IRequest<AuthenticationResultDto>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class AuthenticationResultDto
	{
		public string Token { get; set; }
		public bool Success { get; set; }
		public IEnumerable<string> Errors { get; set; }
	}
}
