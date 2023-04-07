using WebApiTest.EF;
using WebApiTest.ViewModels;

namespace WebApiTest.Services
{
    public class ProductServices : IProductServices
    {
        private readonly MyDbContext _context;

        public ProductServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<int> BuyProduct(BuyProductRequest request)
        {
            if (!_context.Products.Any(x => x.ProductId == request.ProductId))
                throw new Exception($"Can not find product ID = {request.ProductId}");

            var query = from p in _context.Properties
                        join pd in _context.PropertyDetails on p.PropertyId equals pd.PropertyId
                        join pdpd in _context.ProductDetailPropertyDetails on pd.PropertyDetailId equals pdpd.PropertyDetailId
                        where pdpd.ProductId == request.ProductId
                        group new
                        {
                            p.PropertyId,
                            pd.PropertyDetailId
                        } by p.PropertyId;
            var lst = query.ToList();

            foreach (var item in request.PropertiesAndQuantities)
            {
                var ProductDetailId = _context.ProductDetailPropertyDetails.Where(x => x.PropertyDetailId == item.PropertyDetailId).Select(x => x.ProductDetailId);

            }
            return 0;
        }
    }
}
