using Microsoft.AspNetCore.Identity;
using WebApiTest.ViewModels;
using WebApiTest.ViewModels.Result;

namespace WebApiTest.Services
{
    public interface IAccountServices
    {
        Task<IdentityResult> Register(SignUpRequest request);
        Task<ApiResult<string>> Login(SignInRequest request);
    }
}
