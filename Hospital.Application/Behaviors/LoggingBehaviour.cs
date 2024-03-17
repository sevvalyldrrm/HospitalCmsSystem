using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Behaviors
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull, IRequest<TResponse> 
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Loglama işleminin başlangıcını loglayın
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            // Sonraki delegatenin işlemine devam edin (Diğer behaviorlar veya asıl işlem)
            var response = await next();

            // Loglama işleminin sonunu loglayın
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");

            return response;
        }
    }

}
