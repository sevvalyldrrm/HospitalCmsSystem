using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.SurgeryDoctorCommands
{
	public class RemoveSurgeryDoctorCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveSurgeryDoctorCommand(int id)
		{
			Id = id;
		}

	}
}
