using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.WebUI.Models
{
    public class PhoneCaseGetListViewModel
    {
        public List<PhoneCase> Cases { get; set; }
        public List<Vendor> Vendors { get;  set; }
    }
}