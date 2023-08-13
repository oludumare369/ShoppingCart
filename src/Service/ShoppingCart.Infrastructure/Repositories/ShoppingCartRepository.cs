using Dapr;
using Dapr.Client;
using ShoppingCart.Domain.Contracts;
using ShoppingCart.Infrastructure.Persistence;

namespace ShoppingCart.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DaprClient _daprClient;

        public ShoppingCartRepository(DaprClient daprClient)
        {
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
        }

        public async Task<Domain.Entities.ShoppingCart> GetShoppingCartByIdAsync(string Id)
        {
            try
            {
                var shoppingCart = await _daprClient.GetStateAsync<Domain.Entities.ShoppingCart>(Constant.DAPR_STORE_NAME, Id);

                return shoppingCart ??= new Domain.Entities.ShoppingCart() { CustomerId = Id };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<StateEntry<Domain.Entities.ShoppingCart>> UpdateShoppingCartAsync(Domain.Entities.ShoppingCart shoppingCart)
        {
            try
            {
                var state = await _daprClient.GetStateEntryAsync<Domain.Entities.ShoppingCart>(Constant.DAPR_STORE_NAME, shoppingCart.CustomerId);
                state.Value = shoppingCart;

                await state.SaveAsync();

                return state;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteShoppingCartAsync(string Id)
        {
            try
            {
                await _daprClient.DeleteStateAsync(Constant.DAPR_STORE_NAME, Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
