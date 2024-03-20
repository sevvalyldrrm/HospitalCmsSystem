using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.RoleManagementCommands
{

    public class CreateRoleCommand : IRequest<CreateRoleResultDto>
    {
        public string RoleName { get; set; }

        public CreateRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }
    public class CreateRoleResultDto
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
