using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AuthCommands
{
	public class LogoutCommand : IRequest<LogoutCommandResult>
	{
	}

	public class LogoutCommandResult
	{
		public bool Success { get; set; }
		public string Message { get; set; }
	}
}
