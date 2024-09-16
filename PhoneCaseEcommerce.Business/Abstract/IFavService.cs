using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.Business.Abstract
{
    public interface IFavService
    {
        Task<List<Favorite>> GetAllFav();
        Task Add(Favorite favorite);
    }
}
