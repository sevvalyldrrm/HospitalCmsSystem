using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DepartmentDetailCommands
{
	public class UpdateDepartmentDetailCommand : IRequest
	{
		public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public int DepartmentId { get; set; }
    }
}
