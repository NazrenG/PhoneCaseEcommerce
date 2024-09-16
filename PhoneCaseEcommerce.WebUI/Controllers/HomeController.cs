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

        public  async Task<IActionResult> Index()
        { 

            var model = new CasesGetListViewModel
            {
                PremiumList = await phoneCaseService.GetSortedList("Premium"), 
                BestSellerList = await phoneCaseService.GetSortedList("Popular"), 
                CommentedList = await phoneCaseService.GetSortedList("Simple"), 
            };
         
            return View(model);
        }
        
         

     
    }
}
