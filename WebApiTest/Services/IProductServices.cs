using WebApiTest.Entities;
using WebApiTest.ViewModels;

namespace WebApiTest.Services
{
    public interface IProductServices
    {
        Task<int> BuyProduct(ProductDetailRequest request);
        Task<int> UpdateQuantity(ProductDetailRequest request);
        Task<IEnumerable<ProductDetail>> GetProductDetails();
    }
}
