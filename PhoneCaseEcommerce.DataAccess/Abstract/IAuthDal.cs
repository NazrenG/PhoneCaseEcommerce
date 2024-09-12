using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.DataAccess.Abstract
{
    public interface IAuthDal
    {
        Task<User> Register(User user,string password);
        Task<User> LogIn(string userName,string password);
        Task<bool> UserExists(string userName);

    }
}
