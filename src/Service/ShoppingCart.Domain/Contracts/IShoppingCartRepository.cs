namespace ShoppingCart.Domain.Contracts
{
    public interface IShoppingCartRepository
    {
        public Task<Entities.ShoppingCart> GetShoppingCartByIdAsync(string Id);
        public Task<Dapr.StateEntry<Entities.ShoppingCart>> UpdateShoppingCartAsync(Entities.ShoppingCart shoppingCart);
        public Task DeleteShoppingCartAsync(string Id);
    }
}
