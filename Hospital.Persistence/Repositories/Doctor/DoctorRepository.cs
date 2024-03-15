using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
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
    }
}
