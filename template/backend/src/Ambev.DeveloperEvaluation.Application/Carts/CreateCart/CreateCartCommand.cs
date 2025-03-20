using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResponse>
{
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public CartProducts CartProducts { get; set; }
}
