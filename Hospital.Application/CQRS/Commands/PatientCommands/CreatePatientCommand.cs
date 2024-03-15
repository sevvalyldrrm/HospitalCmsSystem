using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.PatientCommands
{
	public class CreatePatientCommand : IRequest
	{
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDischarged { get; set; }
        public int RoleId { get; set; }
    }
}
