using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;
using PhoneCaseEcommerce.WebUI.Models;

namespace PhoneCaseEcommerce.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthDal _authDal;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthDal dal, IConfiguration configuration)
        {
            _authDal = dal;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            var user = new User
            {
                Fullname = vm.Username,
                PhoneNumber = vm.Phone,
                Email = vm.Email,

            };
           await _authDal.Register(user, vm.Password);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            //var user = new User
            //{
            //    Fullname = vm.Username,
            //    PhoneNumber = vm.Phone,
            //    Email = vm.Email,

            //};
            //await _authDal.Register(user, vm.Password);
            //return RedirectToAction("Index", "Home");
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
