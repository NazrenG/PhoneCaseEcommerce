using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.Business.Concretes
{
    public class FavService : IFavService
    {
        private readonly IFavDal favDal;

        public FavService(IFavDal favDal)
        {
            this.favDal = favDal;
        }

        public async Task Add(Favorite favorite)
        {
           await favDal.Add(favorite);
        }

        public async Task<List<Favorite>> GetAllFav()
        {
           return await favDal.GetAllFav();
        }
    }
}
