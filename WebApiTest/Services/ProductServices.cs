using Microsoft.EntityFrameworkCore;
using WebApiTest.EF;
using WebApiTest.Entities;
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
        public async Task<int> BuyProduct(ProductDetailRequest request)
        {
            if (!_context.Products.Any(x => x.ProductId == request.ProductId))
                throw new Exception($"Can not find product ID = {request.ProductId}");

            var query = from pd in _context.PropertyDetails
                        join pdpd in _context.ProductDetailPropertyDetails on pd.PropertyDetailId equals pdpd.PropertyDetailId
                        where pdpd.ProductId == request.ProductId
                        group new
                        {
                            pd.PropertyDetailId,
                            pdpd.ProductDetailId
                        } by pdpd.ProductDetailId;
            query = query.AsQueryable();
            int dem = 0;
            int productDetailId = 0;

            foreach (var item in query)
            {
                dem = 0;

                foreach (var subitem in item)
                {
                    foreach (var propertyDetailId in request.PropertyDetailIds)
                    {
                        if (subitem.PropertyDetailId == propertyDetailId && request.PropertyDetailIds.Count == item.Count())
                            dem++;
                    }
                    if (dem == request.PropertyDetailIds.Count)
                        productDetailId = subitem.ProductDetailId;
                }
            }
            if (productDetailId == 0)
                throw new Exception("Cannot find productDetailId. Check list of PropertyDetailId!");

            var productDetail = await _context.ProductDetails.FindAsync(productDetailId);

            if (productDetail == null)
                throw new Exception($"Can not find ProductDetail with ID = {productDetailId}");

            if (productDetail.Quantity == 0)
                throw new Exception($"ProductDetail with ID = {productDetailId} out of stock!");
            
            if (productDetail.Quantity < request.Quantity)
                throw new Exception($"ProductDetail with ID = {productDetailId} not enough quantity to sell!");

            productDetail.Quantity -= request.Quantity;
            _context.ProductDetails.Update(productDetail);

            //var parentProductDetail = new ProductDetail();
            do
            {
                productDetail = await _context.ProductDetails.FindAsync(productDetail.ParentId);
                productDetail.Quantity-= request.Quantity;
                _context.ProductDetails.Update(productDetail);

            } while (productDetail.ParentId != null);


            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateQuantity(ProductDetailRequest request)
        {
            if (!_context.Products.Any(x => x.ProductId == request.ProductId))
                throw new Exception($"Can not find product ID = {request.ProductId}");

            var query = from pd in _context.PropertyDetails
                        join pdpd in _context.ProductDetailPropertyDetails on pd.PropertyDetailId equals pdpd.PropertyDetailId
                        where pdpd.ProductId == request.ProductId
                        group new
                        {
                            pd.PropertyDetailId,
                            pdpd.ProductDetailId
                        } by pdpd.ProductDetailId;

            //query = query.AsQueryable();

            int dem = 0;
            int productDetailId = 0;

            foreach (var item in query)
            {
                dem = 0;

                foreach (var subitem in item)
                {
                    foreach (var propertyDetailId in request.PropertyDetailIds)
                    {
                        if (subitem.PropertyDetailId == propertyDetailId && request.PropertyDetailIds.Count == item.Count())
                            dem++;
                    }
                    if (dem == request.PropertyDetailIds.Count)
                        productDetailId = subitem.ProductDetailId;
                }
            }
            if (productDetailId == 0)
                throw new Exception("Cannot find productDetailId. Check list of PropertyDetailId!");

            var productDetail = await _context.ProductDetails.FindAsync(productDetailId);

            if (productDetail == null)
                throw new Exception($"Can not find ProductDetail with ID = {productDetailId}");

            int range = request.Quantity - productDetail.Quantity;
            productDetail.Quantity = request.Quantity;
            _context.ProductDetails.Update(productDetail);

            do
            {
                productDetail = await _context.ProductDetails.FindAsync(productDetail.ParentId);
                productDetail.Quantity += range;
                _context.ProductDetails.Update(productDetail);

            } while (productDetail.ParentId != null);


            return await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<ProductDetail>> GetProductDetails()
        {
            var parentProductDetails = _context.ProductDetails.Where(x => x.ParentId == null);
            var productDetails = new List<ProductDetail>();
            //do
            //{
            //    foreach (var item in parentProductDetails)
            //    {
            //        var pds = _context.ProductDetails.Where(x => x.ParentId == item.ProductDetailId);
            //        productDetails.AddRange(pds);
            //    }
            //}while(pds!=null);

            //var pds = _context.ProductDetails.Include(x=>x.Parent).ToList();

            return null;
        }
    }
}
