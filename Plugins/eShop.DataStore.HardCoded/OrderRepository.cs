using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }

        public int CreateOrder(Order order)
        {
            order.OrderId = orders.Count + 1;
            // order.UniqueId = Guid.NewGuid().ToString(); // ??? look at Create call place
            orders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;

            return allOrders.Where(x => x.DateProcessed.HasValue == false);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;

            return allOrders.Where(x => x.DateProcessed.HasValue);
        }

        public Order GetOrder(int id)
        {
            return orders[id];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            foreach (var order in orders)
            {
                if (order.Value.UniqueId == uniqueId) return order.Value;
            }               

            return null;
        }

        public void UpdateOrder(Order order)
        {
            if (order == null || !order.OrderId.HasValue) return;

            var orderId = order.OrderId.Value;

            var o = orders[orderId];
            if (o == null) return;

            orders[orderId] = order;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
