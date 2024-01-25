using eShop.CoreBusiness.Models;
using eShop.UseCases.AdminPortal.ProcessOrderScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.AdminPortal.ProcessOrderScreen
{
    public class ViewOrderDetailUseCase : IViewOrderDetailUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public ViewOrderDetailUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Execute(int orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }
    }
}
