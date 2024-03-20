using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DoctorCommands
{
	public class CreateDoctorCommand : IRequest
	{
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int DepartmentId { get; set; }
        public int IntroductionId { get; set; }
        public string DocFacebook { get; set; }
        public string DocX { get; set; }
        public string DocPinterest { get; set; }
        public string DocSkype { get; set; }
        public string DocLinkedIn { get; set; }
        public string DocTitle { get; set; }
    }
}
