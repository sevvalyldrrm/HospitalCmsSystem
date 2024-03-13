using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DoctorPatientCommands
{
	public class RemoveDoctorPatientCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveDoctorPatientCommand(int id)
		{
			Id = id;
		}

	}
}
