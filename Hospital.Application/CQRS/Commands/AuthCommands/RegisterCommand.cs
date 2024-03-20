using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.LoginCommands
{
	public class RegisterCommand :IRequest<RegisterCommandDto>
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
	}

	public class RegisterCommandDto
	{
		public bool Success { get; set; }

		public IEnumerable<string> Errors { get; set; }

		public string Message { get; set; }
	}
}
