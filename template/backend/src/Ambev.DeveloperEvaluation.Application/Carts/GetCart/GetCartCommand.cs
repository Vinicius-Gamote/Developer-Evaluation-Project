using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public class GetCartCommand : IRequest<GetCartResponse>
{
    public int Id { get; set; }
}
