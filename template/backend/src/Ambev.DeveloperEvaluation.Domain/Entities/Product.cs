namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty; 
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating ProductRating { get; set; }

    public Product(int id, string title, double price, string description, string category, string image, Rating rating)
    {
        Id = id;
        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
        ProductRating = rating;
    }
}

public class Products
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public Products(int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}