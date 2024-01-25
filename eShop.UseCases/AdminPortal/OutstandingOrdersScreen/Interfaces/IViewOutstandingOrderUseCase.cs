using eShop.CoreBusiness.Models;

namespace eShop.UseCases.AdminPortal.OutstandingOrdersScreen.Interfaces
{
    public interface IViewOutstandingOrderUseCase
    {
        IEnumerable<Order> Execute();
    }
}