using eShop.CoreBusiness.Models;

namespace eShop.UseCases.SearchProductScreen.Interfaces
{
    public interface ISearchProductUseCase
    {
        IEnumerable<Product> Execute(string filter);
    }
}