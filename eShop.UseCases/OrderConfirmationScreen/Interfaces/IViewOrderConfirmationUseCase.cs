using eShop.CoreBusiness.Models;

namespace eShop.UseCases.OrderConfirmationScreen.Interfaces
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}
