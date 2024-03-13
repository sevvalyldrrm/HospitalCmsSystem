using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.IntroductionCommands
{
	public class RemoveIntroductionCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveIntroductionCommand(int id)
		{
			Id = id;
		}

	}
}
