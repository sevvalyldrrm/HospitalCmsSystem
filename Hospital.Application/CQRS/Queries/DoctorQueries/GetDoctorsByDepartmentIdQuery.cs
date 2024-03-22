using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DoctorQueries
{
	public class GetDoctorsByDepartmentIdQuery : IRequest<IEnumerable<DoctorDto>>
	{
		public GetDoctorsByDepartmentIdQuery(int departmentId)
		{
			DepartmentId = departmentId;
		}

		public int DepartmentId { get; set; }
	}

	public class DoctorDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

	

	}

	
}
