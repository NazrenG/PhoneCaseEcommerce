using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;
using PhoneCaseEcommerce.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            if (await _authDal.UserExists(vm.Username))
            {
                ModelState.AddModelError("Username", "Username already exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Fullname = vm.Username,
                PhoneNumber = vm.Phone,
                Email = vm.Email,
                Role=(vm.Role=="false" ? "User" : "Admin"),
            };
           await _authDal.Register(user, vm.Password);
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel vm)
        {
            var user = await _authDal.LogIn(vm.Username, vm.Password);
            if (user == null)
            {
                return RedirectToAction("Register");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Fullname),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new { token = tokenString });
        }
    }
}
