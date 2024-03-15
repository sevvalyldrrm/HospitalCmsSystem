using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Interfaces.DoctorInterfaces
{
    public interface IDoctorRepository
    {
       Task<List<Doctor>> GetDoctorsWithDepartments();
    }
}
