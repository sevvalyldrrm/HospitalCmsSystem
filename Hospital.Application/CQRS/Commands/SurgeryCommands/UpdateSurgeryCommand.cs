using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.SurgeryCommands
{
	public class UpdateSurgeryCommand : IRequest
	{
		public int Id { get; set; }
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime SurgeryDate { get; set; }
    }
}
