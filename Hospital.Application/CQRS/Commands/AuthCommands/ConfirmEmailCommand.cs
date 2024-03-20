using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AuthCommands
{
	public class ConfirmEmailCommand :IRequest<ConfirmEmailCommandResult>
	{
		public int UserId { get; set; }

		public string Token { get; set; }
	}

	public class ConfirmEmailCommandResult
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public List<string> Errors { get; set; }
	}
}
