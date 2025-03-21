using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required.");
        }
    }
}
