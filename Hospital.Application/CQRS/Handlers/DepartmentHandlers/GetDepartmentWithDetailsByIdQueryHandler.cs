using HospitalCmsSystem.Application.CQRS.Queries.DepartmentQueries;
using HospitalCmsSystem.Application.CQRS.Results.DepartmentResults;
using HospitalCmsSystem.Application.CQRS.Results.DoctorResults;
using HospitalCmsSystem.Application.Interfaces.DepartmentInterfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentHandlers
{
    public class GetDepartmentWithDetailsByIdQueryHandler: IRequestHandler<GetDepartmentWithDetailsByIdQuery, GetDepartmentWithDetailsByIdQueryResult>
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentWithDetailsByIdQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDepartmentWithDetailsByIdQueryResult> Handle(GetDepartmentWithDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetDepartmentWithDetails(request.Id);
            return  new GetDepartmentWithDetailsByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                DepartmentDetailsId = values.Id,
                Description = values.Description,
                ImagePath = values.ImagePath,
                DescriptionShort = values.DepartmentDetails.DescriptionShort,
                DescriptionLong = values.DepartmentDetails.DescriptionLong,
                Title = values.DepartmentDetails.Title, 
            };
        }
    }
}
