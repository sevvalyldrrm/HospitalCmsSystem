using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.RoleManagementCommands
{
    public class AssignRoleToUserCommand : IRequest<AssignRoleToUserResultDto>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; } // RoleId özelliği eklendi.

        public AssignRoleToUserCommand(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
    public class AssignRoleToUserResultDto
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
