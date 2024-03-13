﻿using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.SurgeryDoctorCommands
{
	public class UpdateSurgeryDoctorCommand : IRequest
	{
		public int Id { get; set; }
        public int DoctorId { get; set; }

        public int SurgeryId { get; set; }
    }
}
