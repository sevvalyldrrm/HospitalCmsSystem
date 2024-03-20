using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AuthCommands
{
	public class PasswordResetRequestCommand :IRequest<PasswordResetRequestCommandDto>
	{
		public string Email { get; set; }
	}
	public class PasswordResetRequestCommandDto
	{
		public bool Success { get; set; }
		public List<string> Errors { get; set; }
		public string Message { get; set; }
	}
}
