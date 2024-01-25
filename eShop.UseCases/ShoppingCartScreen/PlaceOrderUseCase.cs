using eShop.CoreBusiness.Models;
using eShop.CoreBusiness.Services;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.ShoppingCartScreen.Interfaces;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public PlaceOrderUseCase(IShoppingCart shoppingCart, IOrderRepository orderRepository, IOrderService orderService, IShoppingCartStateStore shoppingCartStateStore)
        {
            _shoppingCart = shoppingCart;
            _orderService = orderService;
            _orderRepository = orderRepository;
            _shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<string> Execute(Order order)
        {            
            await _shoppingCart.UpdateOrderAsync(order);

            order.DatePlaced = DateTime.Now;
            order.UniqueId = Guid.NewGuid().ToString();

            bool IsValid = _orderService.ValidateCreateOrder(order);

            if (IsValid)
            {
                int orderId = _orderRepository.CreateOrder(order);
                order = _orderRepository.GetOrder(orderId);

                await _shoppingCart.EmptyAsync();
                // after Empty we need to update Cart Count
                _shoppingCartStateStore.LineItemsCountUpdated();

                return order.UniqueId;
            }            

            return null;
        }
    }
}
