using eShop.CoreBusiness.Models;

namespace eShop.UseCases.PluginInterfaces.DataStore
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts(string filter);
        public Product GetProduct(int id);
    }
}
