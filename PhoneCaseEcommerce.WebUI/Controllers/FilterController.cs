using Microsoft.AspNetCore.Mvc;
using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.Entities.Models;
using PhoneCaseEcommerce.WebUI.Models;
using System.Security.Claims;

namespace PhoneCaseEcommerce.WebUI.Controllers
{
    public class FilterController : Controller
    {

        private readonly IPhoneCaseService phoneCaseService;
        private readonly IVendorService vendorService;
        private readonly IModelService modelService;
        private readonly IColorService colorService;
        private readonly IFavService favService;

        public FilterController(IPhoneCaseService phoneCaseService, IVendorService vendorService, IModelService modelService, IColorService colorService, IFavService favService)
        {
            this.phoneCaseService = phoneCaseService;
            this.vendorService = vendorService;
            this.modelService = modelService;
            this.colorService = colorService;
            this.favService = favService;
        }

        public async Task<IActionResult> Index(int vendorId = 0, int modelId = 0, int colorId = 0)
        {
            ViewData["vendorId"] = vendorId;
            ViewData["modelId"] = modelId;
            ViewData["colorId"] = colorId;

            var items = await phoneCaseService.GetCaseWithModelVendor(vendorId, modelId, colorId);

            var vendors = await vendorService.GetAllVendor();
            var models = await modelService.GetModelListAsync();
            var colors = await colorService.GetColorListAsync();

            var cases = new PhoneCaseGetListViewModel
            {
                Cases = items,
                Vendors = vendors,
                Models = models,
                Colors = colors
            };
            return View(cases);
        }
        

            [HttpPost]
        public IActionResult AddFavorites(int userId,int caseId)
        {
            var userIdd = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdd))
            {
                return Unauthorized();  // Eğer token geçersizse veya userId yoksa hata veriyoruz.
            }
            var userIntId = int.Parse(userIdd);  // JWT'den alınan userId string olabilir, bunu int'e çeviriyoruz.

            var item = new Favorite
            {
                UserId = userIntId,
                PhoneCaseId = caseId
            };
            favService.Add(item);   
            return RedirectToAction("Index","Home");
        }
    }
}
