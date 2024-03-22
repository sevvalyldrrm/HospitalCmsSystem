using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces.HospitalCmsSystem.Persistence.Repositories;
using HospitalCmsSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Persistence.Repositories.Doctor
{
	public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;
        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Doctor>> GetDoctorsWithDepartments()
        {
            return await _context.Doctors.Include(x => x.Department).ToListAsync();
        }

		public async Task<Domain.Entities.Doctor> GetDoctorWithWorkingHours(int doctorId)
		{
			return await _context.Doctors
                .Include(d => d.WorkingHours) // Assuming WorkingHours is a navigation property
                .SingleOrDefaultAsync(d => d.Id == doctorId);
		}

		public async Task<List<Domain.Entities.Doctor>> GetQueryable(int id)
		{
            return await _context.Doctors.Where(p => p.DepartmentId == id).ToListAsync();
		}
	}
}
