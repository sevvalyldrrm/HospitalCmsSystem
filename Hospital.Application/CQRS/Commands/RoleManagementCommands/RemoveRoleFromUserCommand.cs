using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.RoleManagementCommands
{
    public class RemoveRoleFromUserCommand : IRequest<RemoveRoleFromUserResultDto>
    {
        public int UserId { get; set; }
        public string Role { get; set; }

        public RemoveRoleFromUserCommand(int userId, string role)
        {
            UserId = userId;
            Role = role;
        }
    }
    public class RemoveRoleFromUserResultDto
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
