namespace eShop.UseCases.PluginInterfaces.StateStore
{
    public interface IShoppingCartStateStore : IStateStore
    {
        Task<int> GetLineItemsCount();
        void LineItemsCountUpdated();
        void ProductQuantityUpdated();
    }
}
