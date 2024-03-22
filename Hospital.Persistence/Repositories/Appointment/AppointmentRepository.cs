using HospitalCmsSystem.Application.Interfaces.AppointmentInterfaces;
using HospitalCmsSystem.Application.Interfaces.AppointmentInterfaces.HospitalCmsSystem.Persistence.Repositories;
using HospitalCmsSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Persistence.Repositories.Appointment
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly AppDbContext _context;

		public AppointmentRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Domain.Entities.Appointment>> GetAppointmentsByDoctor(int doctorId, DateTime date)
		{
			return await _context.Appointments
			   .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date)
			   .ToListAsync();
		}

		public async Task<List<Domain.Entities.Appointment>> GetQueryable(int id)
		{
			return await _context.Appointments.Where(p => p.DoctorId == id).ToListAsync();
		}
	}
}
