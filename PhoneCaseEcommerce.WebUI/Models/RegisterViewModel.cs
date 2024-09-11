using Microsoft.Identity.Client;
using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.WebUI.Models
{
    public class RegisterViewModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Phone {  get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
