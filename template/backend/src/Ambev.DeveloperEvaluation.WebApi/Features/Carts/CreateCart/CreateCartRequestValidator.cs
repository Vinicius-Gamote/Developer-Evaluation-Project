using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId must be greater than 0.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("A date is required.");
    }
}
