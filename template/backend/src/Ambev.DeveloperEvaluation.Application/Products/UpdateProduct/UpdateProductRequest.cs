using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public Rating ProductRating { get; set; }
    }
}
