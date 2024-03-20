using HospitalCmsSystem.Application.CQRS.Commands.RoleManagementCommands;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.RoleManagementHandlers
{
  

    public class ListRolesQueryHandler : IRequestHandler<ListRolesQuery, List<AppRole>>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public ListRolesQueryHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<AppRole>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
        {
            return _roleManager.Roles.ToList();
        }
    }
    public class ListRolesQuery : IRequest<List<AppRole>>
    {
    }

}
