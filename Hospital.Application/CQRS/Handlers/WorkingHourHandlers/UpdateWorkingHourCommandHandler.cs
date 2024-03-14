using HospitalCmsSystem.Application.CQRS.Commands.WorkingHourCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.WorkingHourHandlers
{
    public class UpdateWorkingHourCommandHandler : IRequestHandler<UpdateWorkingHourCommand>
    {
        private readonly IRepository<WorkingHour> _repository;

        public UpdateWorkingHourCommandHandler(IRepository<WorkingHour> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateWorkingHourCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.DoctorId = request.DoctorId;
            values.DayOfWeek = request.DayOfWeek;
            values.StartTime = request.StartTime;
            values.EndTime = request.EndTime;
            values.IsOffDay = request.IsOffDay;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}
