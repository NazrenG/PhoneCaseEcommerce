using Microsoft.AspNetCore.Mvc;
using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.WebUI.Models;
using System.Diagnostics;

namespace PhoneCaseEcommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhoneCaseService phoneCaseService;

        public HomeController(IPhoneCaseService phoneCaseService)
        {
            this.phoneCaseService = phoneCaseService;
        }

        public async Task<IActionResult> Index()
        {
         var items= await  phoneCaseService.GetCaseWithModelVendor();

            var cases = new PhoneCaseGetListViewModel
            {
                Cases = items
            };
            return View(cases);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
