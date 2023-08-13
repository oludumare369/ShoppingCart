using Dapr;
using Dapr.Client;
using StateManagement.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace StateManagement.Repositories
{
    internal class StateManagementRepository<T> : IStateManagementRepository<T> where T : class
    {
        private readonly DaprClient _daprClient;

        public StateManagementRepository(DaprClient daprClient)
        {
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
        }

        public async Task<T> GetAsync(string storeName, string Id)
        {
            try
            {
                return await _daprClient.GetStateAsync<T>(storeName, Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task SaveAsync(StateEntry<T> state)
        {
            try
            {
                await state.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<StateEntry<T>> UpdateAsync(string storeName, string Id, T model)
        {
            try
            {
                var state = await _daprClient.GetStateEntryAsync<T>(storeName, Id);
                state.Value = model;

                return state;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task DeleteAsync(string storeName, string Id)
        {
            try
            {
                await _daprClient.DeleteStateAsync(storeName, Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
