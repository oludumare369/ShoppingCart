using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Dtos
{
    public class ShoppingCartDto
    {
        public required string CustomerId { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in ShoppingCartItems)
                {
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }
    }
}
