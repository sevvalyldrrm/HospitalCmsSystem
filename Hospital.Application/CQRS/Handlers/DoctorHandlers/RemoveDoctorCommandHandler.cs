using HospitalCmsSystem.Application.CQRS.Commands.DoctorCommands;
using HospitalCmsSystem.Application.CQRS.Results.DoctorResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorHandlers
{
	public class RemoveDoctorCommandHandler : IRequestHandler<RemoveDoctorCommand>
	{
		private readonly IRepository<Doctor> _repository;

		public RemoveDoctorCommandHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveDoctorCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
