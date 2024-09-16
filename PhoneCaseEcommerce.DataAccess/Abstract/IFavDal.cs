using PhoneCaseEcommerce.Core;
using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.DataAccess.Abstract
{
   public interface IFavDal:IEntityRepository<Favorite>
    {
        Task<List<Favorite>> GetAllFav();
    }
}
