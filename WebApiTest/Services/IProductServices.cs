using WebApiTest.ViewModels;

namespace WebApiTest.Services
{
    public interface IProductServices
    {
        Task<int> BuyProduct(BuyProductRequest request);
    }
}
