using HospitalCmsSystem.Application.CQRS.Commands.DoctorCommands;
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
	public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand>
	{
		private readonly IRepository<Doctor> _repository;

		public CreateDoctorCommandHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Doctor()
			{
				Speacialty=request.Speacialty,
                DepartmentId=request.DepartmentId,
                RoleId=request.RoleId,
                IntroductionId=request.IntroductionId,
                DocFacebook=request.DocFacebook,
                DocX=request.DocX,
                DocPinterest=request.DocPinterest,
                DocSkype=request.DocSkype,
                DocLinkedIn=request.DocLinkedIn,
                DocTitle=request.DocTitle,

            });
		}
	}
}
