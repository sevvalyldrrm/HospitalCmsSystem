using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.EducationCommands
{
	public class UpdateEducationCommand : IRequest
	{
		public int Id { get; set; }
        public string Year { get; set; }

        public string University { get; set; }

        public string Explanation { get; set; }

        public int DoctorId { get; set; }
    }
}
