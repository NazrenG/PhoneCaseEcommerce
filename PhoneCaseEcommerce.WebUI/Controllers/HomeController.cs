using Microsoft.AspNetCore.Mvc;
using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.WebUI.Models;
using System.Diagnostics;

namespace PhoneCaseEcommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhoneCaseService phoneCaseService;
        private readonly IVendorService vendorService;

        public HomeController(IPhoneCaseService phoneCaseService, IVendorService vendorService)
        {
            this.phoneCaseService = phoneCaseService;
            this.vendorService = vendorService;
        }

        public async Task<IActionResult> Index(int vendorId=0)
        {
         var items= await  phoneCaseService.GetCaseWithModelVendor(vendorId);
            var vendors = await vendorService.GetAllVendor();

            var cases = new PhoneCaseGetListViewModel
            {
                Cases = items,
                Vendors= vendors
            };
            return View(cases);
        }
        public async Task<IActionResult> FilterByVendorName(int vendorId)
        {
            var filter = await phoneCaseService.FilterByVendorName(vendorId);

            return RedirectToAction("Index",filter);
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
