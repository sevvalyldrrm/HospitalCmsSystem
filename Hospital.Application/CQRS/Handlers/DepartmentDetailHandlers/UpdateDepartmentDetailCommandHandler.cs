using HospitalCmsSystem.Application.CQRS.Commands.DepartmentDetailCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentDetailHandlers
{
    public class UpdateDepartmentDetailCommandHandler : IRequestHandler<UpdateDepartmentDetailCommand>
    {
        private readonly IRepository<DepartmentDetail> _repository;

        public UpdateDepartmentDetailCommandHandler(IRepository<DepartmentDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDepartmentDetailCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Title = request.Title;
            values.DescriptionLong = request.DescriptionLong;
            values.DescriptionShort = request.DescriptionShort;
            values.DepartmentId = request.DepartmentId;
            await _repository.UpdateAsync(values);
        }
    }


}
