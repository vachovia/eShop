using eShop.CoreBusiness.Models;
using eShop.DataStore.SQL.Dapper.Helpers;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Product GetProduct(int id)
        {
            return _dataAccess.QuerySingle<Product, dynamic>("SELECT * FROM Product WHERE ProductId = @ProductId", new { ProductId = id });
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            List<Product> list;
            if (string.IsNullOrWhiteSpace(filter))
            {
                list = _dataAccess.Query<Product, dynamic>("SELECT * FROM Product", new { });
            }
            else
            {
                list = _dataAccess.Query<Product, dynamic>("SELECT * FROM Product WHERE Name like '%' + @Filter + '%'", new { Filter = filter });
            }                

            return list.AsEnumerable();
        }
    }
}
