using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.IntroductionCommands
{
	public class CreateIntroductionCommand : IRequest
	{
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public string MySkills { get; set; }
        public WorkingHour WorkingHour { get; set; }
    }
}
