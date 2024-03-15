using HospitalCmsSystem.Application.CQRS.Queries.DoctorQueries;
using HospitalCmsSystem.Application.CQRS.Results.DoctorResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorHandlers
{
    public class GetDoctorsWithDepartmentQueryHandler :IRequestHandler<GetDoctorsWithDepartmentQuery, List<GetDoctorsWithDepartmentQueryResult>>
    {
        private readonly IDoctorRepository _repository;

        public GetDoctorsWithDepartmentQueryHandler(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task< List<GetDoctorsWithDepartmentQueryResult>>Handle(GetDoctorsWithDepartmentQuery request, CancellationToken cancellationToken)
        {
            var values =  await _repository.GetDoctorsWithDepartments();
            return values.Select(x => new GetDoctorsWithDepartmentQueryResult
            {
                Name = x.Name,
                Speacialty = x.Speacialty,
                DepartmentId = x.DepartmentId,
                DepartmentDescription = x.Department.Description,
                DepartmentName = x.Department.Name,
                Id = x.Id,
                DocFacebook = x.DocFacebook,
                DocLinkedIn = x.DocLinkedIn,
                DocPinterest = x.DocPinterest,
                DocSkype = x.DocSkype,
                DocTitle = x.DocTitle,
                RoleId = x.RoleId,
                DocX = x.DocX,
                IntroductionId = x.IntroductionId,
                DepartmentImagePath = x.Department.ImagePath,
                DepartmentDetailsId = x.Department.DepartmentDetailsId
            }).ToList();
        
        }
    }
}
