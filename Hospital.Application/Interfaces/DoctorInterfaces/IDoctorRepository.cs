using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Interfaces.DoctorInterfaces
{
	namespace HospitalCmsSystem.Persistence.Repositories
	{
		public interface IDoctorRepository
		{
			Task<Doctor> GetDoctorWithWorkingHours(int doctorId);
			Task<List<Doctor>> GetDoctorsWithDepartments();
			Task<List<Doctor>> GetQueryable(int doctorId);


		}
	}


}
