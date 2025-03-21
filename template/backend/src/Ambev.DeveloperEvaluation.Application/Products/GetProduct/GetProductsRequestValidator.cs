using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductCommand>
    {
        public GetProductsRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required.");
        }
    }
}
