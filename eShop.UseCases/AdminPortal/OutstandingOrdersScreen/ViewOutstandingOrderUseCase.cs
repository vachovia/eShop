using eShop.CoreBusiness.Models;
using eShop.UseCases.AdminPortal.OutstandingOrdersScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutstandingOrderUseCase : IViewOutstandingOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public ViewOutstandingOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return _orderRepository.GetOutstandingOrders();
        }
    }
}
