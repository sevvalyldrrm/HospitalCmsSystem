using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.SurgeryCommands
{
	public class RemoveSurgeryCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveSurgeryCommand(int id)
		{
			Id = id;
		}

	}
}
