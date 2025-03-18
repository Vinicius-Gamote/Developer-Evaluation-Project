namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public Products CartProducts { get; set; }

    public Cart(int id, int userId, DateTime date, Products cartProducts)
    {
        Id = id;
        UserId = userId;
        Date = date;
        CartProducts = cartProducts;
    }
}