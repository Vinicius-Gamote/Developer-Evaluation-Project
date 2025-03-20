using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public CartProducts CartProducts { get; set; }
}
