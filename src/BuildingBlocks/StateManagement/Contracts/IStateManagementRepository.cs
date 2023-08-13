namespace StateManagement.Contracts
{
    public interface IStateManagementRepository<T> where T : class
    {
        public Task DeleteAsync(string storeName, string Id);
        public Task<T> GetAsync(string storeName, string Id);
        public Task<Dapr.StateEntry<T>> UpdateAsync(string storeName, string Id, T model);
        public Task SaveAsync(Dapr.StateEntry<T> state);
    }
}
