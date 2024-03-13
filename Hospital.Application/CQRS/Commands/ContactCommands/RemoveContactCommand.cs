using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.ContactCommands
{
	public class RemoveContactCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveContactCommand(int id)
		{
			Id = id;
		}

	}
}
