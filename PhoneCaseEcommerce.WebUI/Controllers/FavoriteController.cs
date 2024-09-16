using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.WebUI.Models;

namespace PhoneCaseEcommerce.WebUI.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavService _favService;

        public FavoriteController(IFavService favService)
        {
            _favService = favService;
        }

        public async Task<IActionResult> Index()
        {
            var items=await _favService.GetAllFav();
            var model = new FavoriteListViewModel
            {
                Cases = items.Select(c => c.PhoneCase).ToList(),
            };
            return View(model);
        }
    }
}
