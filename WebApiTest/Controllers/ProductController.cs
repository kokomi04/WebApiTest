using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Services;
using WebApiTest.ViewModels;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpPut("buy")]
        public async Task<IActionResult> BuyProduct(ProductDetailRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _services.BuyProduct(request) == 0)
                return BadRequest();
            return Ok("Mua thanh cong!");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateQuantity(ProductDetailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _services.UpdateQuantity(request) == 0)
                return BadRequest();
            return Ok("Cap nhat thanh cong!");
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        {
            var productDetails = _services.GetProductDetails();
            if (productDetails == null)
                return BadRequest("Danh sach trong");
            return Ok(productDetails);
        }
    }
}
