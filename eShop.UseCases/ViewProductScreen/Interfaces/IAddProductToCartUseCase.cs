namespace eShop.UseCases.ViewProductScreen.Interfaces
{
    public interface IAddProductToCartUseCase
    {
        Task Execute(int productId);
    }
}