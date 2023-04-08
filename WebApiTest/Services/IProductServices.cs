using WebApiTest.Entities;
using WebApiTest.ViewModels;
using WebApiTest.ViewModels.PagingCommon;

namespace WebApiTest.Services
{
    public interface IProductServices
    {
        Task<int> BuyProduct(ProductDetailRequest request);
        Task<int> UpdateQuantity(ProductDetailRequest request);
        Task<PageResult<ProductDetail>> GetProductDetails(ProductPagingRequest request);
    }
}
