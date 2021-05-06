using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Surzor.Application.Features.Responders.Commands
{
    public class CreateResponderCommandValidator : AbstractValidator<CreateResponderCommand>
    {

        public CreateResponderCommandValidator()
        {
            RuleFor(p => p.Mail)
                .EmailAddress()
                .NotEmpty().NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("Maximum length for {PropertyName} is 50 char");
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(256).WithMessage("Maximum length for {PropertyName} is 256 char");
            RuleFor(p => p)
                .MustAsync(CustomValidation)
                .WithMessage("Solve validation problem");
        }

        public async Task<bool> CustomValidation(CreateResponderCommand command, CancellationToken cancellationToken) =>
            true;
    }
}
