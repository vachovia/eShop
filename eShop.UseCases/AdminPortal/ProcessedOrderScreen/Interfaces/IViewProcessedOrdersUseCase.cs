using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AdminPortal.ProcessedOrderScreen.Interfaces
{
    public interface IViewProcessedOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}
