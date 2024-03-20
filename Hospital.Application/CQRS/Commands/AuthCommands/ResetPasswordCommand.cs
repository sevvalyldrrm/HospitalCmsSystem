using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AuthCommands
{
	public class ResetPasswordCommand : IRequest<ResetPasswordCommandDto>
	{
		public string Email { get; set; }
		public string Token { get; set; }
		public string NewPassword { get; set; }
	}

	public class ResetPasswordCommandDto
	{
		public bool Success { get; set; }
		public List<string> Errors { get; set; }
		public string Message { get; set; }
	}
}
