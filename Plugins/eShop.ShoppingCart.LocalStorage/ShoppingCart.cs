using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string cstrShoppingCar = "eShop.ShoppingCart";
        private readonly IJSRuntime _jsRuntime;
        private readonly IProductRepository _productRepository;

        public ShoppingCart(IJSRuntime jsRuntime, IProductRepository productRepository)
        {
            _jsRuntime = jsRuntime;
            _productRepository = productRepository;
        }        

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);

            return order;
        }

        public Task EmptyAsync()
        {
            return SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            var order = await GetOrder();

            return order;
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await SetOrder(order);

            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quanity)
        {
            var order = await GetOrder();

            if(quanity < 0)
            {
                return order;
            }
            else if (quanity == 0)
            {
                return await DeleteProductAsync(productId);
            }

            var lineItem = order.LineItems.SingleOrDefault(i => i.ProductId == productId);

            if(lineItem != null)
            {
                lineItem.Quantity = quanity;    
            }

            await SetOrder(order);

            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order order;

            var strOrder = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCar);

            if (!string.IsNullOrEmpty(strOrder) && strOrder.ToLower() != "null")
            {
                order = JsonConvert.DeserializeObject<Order>(strOrder) ?? new Order();
            }
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var item in order.LineItems)
            {
                item.Product = _productRepository.GetProduct(item.ProductId);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            var strOrder = JsonConvert.SerializeObject(order);
            await _jsRuntime.InvokeAsync<string>("localStorage.setItem", cstrShoppingCar, strOrder);
        }
    }
}
