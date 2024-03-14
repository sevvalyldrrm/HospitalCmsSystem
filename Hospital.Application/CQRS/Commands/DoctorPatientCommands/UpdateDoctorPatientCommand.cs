using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DoctorPatientCommands
{
	public class UpdateDoctorPatientCommand : IRequest
	{
		public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
