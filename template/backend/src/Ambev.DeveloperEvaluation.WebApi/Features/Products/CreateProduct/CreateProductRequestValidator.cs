using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title).NotEmpty().Length(10, 30);
        RuleFor(product => product.Price).NotEmpty();
        RuleFor(product => product.Description).NotEmpty().Length(10, 100);
        RuleFor(product => product.Category).NotEmpty().Length(5, 20);
        RuleFor(product => product.Image).NotEmpty().Matches(@"^https:\/\/.+$");
        RuleFor(product => product.ProductRating.Rate).NotEmpty();
        RuleFor(product => product.ProductRating.Count).NotEmpty();
    }
}