using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class LoggerPipelineBehavior<TRequest, TResponse>
     : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
    

        public  async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Executing Request {Request}" , typeof(TRequest).Name);
            var response =await next();
            _logger.LogInformation("Executed Request {Request}", typeof(TRequest).Name);

            return response;
        }
    }
}
