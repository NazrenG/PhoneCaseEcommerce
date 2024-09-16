using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneCaseEcommerce.WebUI.Entities
{
    public class CustomIdentiyDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomIdentiyDbContext(DbContextOptions<CustomIdentiyDbContext> options)
      : base(options)
        {

        }
    }
}
