using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DepartmentDetailCommands
{
	public class RemoveDepartmentDetailCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveDepartmentDetailCommand(int id)
		{
			Id = id;
		}

	}
}
