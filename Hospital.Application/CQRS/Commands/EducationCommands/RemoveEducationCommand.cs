using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.EducationCommands
{
	public class RemoveEducationCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveEducationCommand(int id)
		{
			Id = id;
		}

	}
}
