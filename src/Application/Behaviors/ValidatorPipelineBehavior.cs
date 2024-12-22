using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = validators
              .Select(validator => validator.Validate(request))
              .SelectMany(result => result.Errors)
              .Where(error => error != null)
              .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
