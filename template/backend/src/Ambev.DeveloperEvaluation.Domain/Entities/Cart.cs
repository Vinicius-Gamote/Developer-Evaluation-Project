namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart 
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public CartProducts CartProducts { get; set; }

    public Cart(int id, Guid userId, DateTime date, CartProducts cartProducts)
    {
        Id = id;
        UserId = userId;
        Date = date;
        CartProducts = cartProducts;
    }
}