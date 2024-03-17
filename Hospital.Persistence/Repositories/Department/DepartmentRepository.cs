using HospitalCmsSystem.Application.Interfaces.DepartmentInterfaces;
using HospitalCmsSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Persistence.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Department> GetDepartmentWithDetails(int id)
        {
            return await _context.Departments.Include(x=> x.DepartmentDetails).FirstOrDefaultAsync(x=> x.Id == id);  
        }
    }
}
