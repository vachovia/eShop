namespace eShop.UseCases.AdminPortal.ProcessOrderScreen.Interfaces
{
    public interface IProcessOrderUseCase
    {   
        bool Execute(int orderId, string adminUserName);
    }
}