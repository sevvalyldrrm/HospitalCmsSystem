﻿using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Interfaces.AppointmentInterfaces
{
	namespace HospitalCmsSystem.Persistence.Repositories
	{
		public interface IAppointmentRepository
		{
			Task<List<Appointment>> GetAppointmentsByDoctor(int doctorId, DateTime date);
		}
	}
}
