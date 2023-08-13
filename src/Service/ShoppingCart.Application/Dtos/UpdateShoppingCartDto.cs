using MediatR;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Dtos
{
    public class UpdateShoppingCartDto : IRequest<ShoppingCartDto>
    {
        public string CustomerId { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
