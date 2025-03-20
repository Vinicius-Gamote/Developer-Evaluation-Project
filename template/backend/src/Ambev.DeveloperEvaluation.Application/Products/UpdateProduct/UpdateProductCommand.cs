using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public Rating ProductRating { get; set; }
    }
}
