using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    public UpdateCartRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Cart ID must be greater than zero.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Cart userId is required.");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Updated date is required.");
    }
}
