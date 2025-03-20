namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class CartProducts
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public Products(int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}