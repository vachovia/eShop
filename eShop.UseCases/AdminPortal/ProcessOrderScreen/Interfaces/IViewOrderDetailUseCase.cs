using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AdminPortal.ProcessOrderScreen.Interfaces
{
    public interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}