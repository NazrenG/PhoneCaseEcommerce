using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.WebUI.Models
{
    public class CasesGetListViewModel
    { 
        public List<PhoneCase>? CommentedList { get;   set; }
        public List<PhoneCase>? BestSellerList { get;   set; }
        public List<PhoneCase>? PremiumList { get;   set; }
    }
}