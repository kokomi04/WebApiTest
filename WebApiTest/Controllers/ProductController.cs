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


        [HttpPost]
        public async Task<IActionResult> BuyProduct(BuyProductRequest request)
        {
            var kq = await _services.BuyProduct(request);
            return Ok(kq);
        }
    }
}
