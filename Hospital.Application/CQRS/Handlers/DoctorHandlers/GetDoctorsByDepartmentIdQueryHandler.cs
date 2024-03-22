using HospitalCmsSystem.Application.CQRS.Queries.DoctorQueries;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces.HospitalCmsSystem.Persistence.Repositories;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorHandlers
{
	public class GetDoctorsByDepartmentIdQueryHandler : IRequestHandler<GetDoctorsByDepartmentIdQuery, IEnumerable<DoctorDto>>
	{
		private readonly IDoctorRepository _doctorRepository;

		public GetDoctorsByDepartmentIdQueryHandler(IDoctorRepository doctorRepository)
		{
			_doctorRepository = doctorRepository;
		}

		public async Task<IEnumerable<DoctorDto>> Handle(GetDoctorsByDepartmentIdQuery request, CancellationToken cancellationToken)
		{
			var doctors = await _doctorRepository.GetQueryable(request.DepartmentId);

			var doctorDtos = doctors.Select(d => new DoctorDto
			{
				Id = d.Id,
				Name = d.Name,
			}).ToList();

			return doctorDtos;
		}
	}
}
