using HospitalCmsSystem.Application.CQRS.Commands.RoleManagementCommands;
using HospitalCmsSystem.Application.CQRS.Handlers.RoleManagementHandlers;
using HospitalCmsSystem.Dto.RoleManagement;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalCmsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleToUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "Role assignment successful." });
        }
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "Role created successfully." });
        }
        [HttpDelete("delete-role/{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Role name must be provided.");
            }

            var command = new DeleteRoleCommand(roleName);
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = $"Role '{roleName}' deleted successfully." });
        }
        [HttpGet("list-roles")]
        public async Task<ActionResult<List<IdentityRole<int>>>> ListRoles()
        {
            var query = new ListRolesQuery();
            var roles = await _mediator.Send(query);
            return Ok(roles);
        }
        [HttpPost("remove-role-from-user")]
        public async Task<IActionResult> RemoveRoleFromUser(RemoveRoleFromUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "Role removed from user successfully." });
        }
    }
}
