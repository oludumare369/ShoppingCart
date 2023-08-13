using MediatR;

namespace ShoppingCart.Application.Dtos
{
    public class DeleteShoppingCartDto : IRequest<Unit>
    {
        public required string Id { get; set; }
    }
}
