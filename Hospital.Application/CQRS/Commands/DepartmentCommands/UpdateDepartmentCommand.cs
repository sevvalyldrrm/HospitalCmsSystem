using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DepartmentCommands
{
	public class UpdateDepartmentCommand : IRequest
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentDetailsId { get; set; }
        public string? ImagePath { get; set; }
    }
}
