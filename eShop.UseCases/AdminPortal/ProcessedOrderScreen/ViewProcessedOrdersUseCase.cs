using eShop.CoreBusiness.Models;
using eShop.UseCases.AdminPortal.ProcessedOrderScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.AdminPortal.ProcessedOrderScreen
{
    public class ViewProcessedOrdersUseCase : IViewProcessedOrdersUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public ViewProcessedOrdersUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return _orderRepository.GetProcessedOrders();
        }
    }
}
