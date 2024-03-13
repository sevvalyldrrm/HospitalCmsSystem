using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.BlogImageCommands
{
	public class RemoveBlogImageCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveBlogImageCommand(int id)
		{
			Id = id;
		}

	}
}
