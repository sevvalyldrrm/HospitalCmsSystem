using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AdminCommands
{
	public class UpdateAdminCommand : IRequest
	{
		public int Id { get; set; }
		public string GitHubAcc { get; set; }
	}
}
