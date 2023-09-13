using EndPoint.AspCore.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.AspCore.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
