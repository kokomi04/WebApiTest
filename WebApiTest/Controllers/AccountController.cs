using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Entities;
using WebApiTest.Services;
using WebApiTest.ViewModels;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _services;

        public AccountController(IAccountServices services)
        {
            _services = services;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(SignInRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _services.Login(request);
            if(result.ResultObj == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(SignUpRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _services.Register(request);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return Ok(result.Succeeded);
        }
    }
}
