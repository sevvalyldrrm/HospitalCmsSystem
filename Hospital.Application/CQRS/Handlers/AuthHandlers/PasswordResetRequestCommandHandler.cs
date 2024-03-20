using HospitalCmsSystem.Application.CQRS.Commands.AuthCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AuthHandlers
{
    public class PasswordResetRequestCommandHandler : IRequestHandler<PasswordResetRequestCommand, PasswordResetRequestCommandDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PasswordResetRequestCommandHandler(
            UserManager<AppUser> userManager,
            IEmailService emailService,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _emailService = emailService;
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PasswordResetRequestCommandDto> Handle(PasswordResetRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new PasswordResetRequestCommandDto
                {
                    Success = false,
                    Errors = new List<string> { "User not found." }
                };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;

            // 'ResetPassword' action ve 'Auth' controller isimlerinizi kontrol edin
            var resetLink = urlHelper.Action("ResetPassword", "Auth", new { email = user.Email, token = token }, scheme);

            await _emailService.SendEmailAsync(user.Email, "Reset Your Password", $"Please reset your password by clicking <a href=\"{resetLink}\">here</a>.");

            return new PasswordResetRequestCommandDto
            {
                Success = true,
                Message = "Password reset link sent to email successfully."
            };
        }
    }
}
