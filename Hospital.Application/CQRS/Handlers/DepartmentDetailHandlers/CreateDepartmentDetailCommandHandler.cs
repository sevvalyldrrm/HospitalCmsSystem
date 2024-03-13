using HospitalCmsSystem.Application.CQRS.Commands.DepartmentDetailCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentDetailHandlers
{
	public class CreateDepartmentDetailCommandHandler : IRequestHandler<CreateDepartmentDetailCommand>
	{
		private readonly IRepository<DepartmentDetail> _repository;

		public CreateDepartmentDetailCommandHandler(IRepository<DepartmentDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDepartmentDetailCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new DepartmentDetail()
			{
			 Title= request.Title,
			 DescriptionLong=request.DescriptionLong,
			 DescriptionShort=request.DescriptionShort,
			 DepartmentId=request.DepartmentId,
				
			});
		}
	}
}
