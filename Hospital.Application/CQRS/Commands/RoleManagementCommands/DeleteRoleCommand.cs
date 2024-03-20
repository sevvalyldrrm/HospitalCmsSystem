using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.RoleManagementCommands
{
    public class DeleteRoleCommand : IRequest<DeleteRoleResultDto>
    {
        public string RoleName { get; set; }

        public DeleteRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }
    public class DeleteRoleResultDto
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
