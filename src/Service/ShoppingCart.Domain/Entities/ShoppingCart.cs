namespace ShoppingCart.Domain.Entities
{
    public class ShoppingCart
    {
        public string CustomerId { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
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
