﻿using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.PatientCommands
{
	public class UpdatePatientCommand : IRequest
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDischarged { get; set; }
    }
}
