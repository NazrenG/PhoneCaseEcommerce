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
    public class ColorService : IColorService
    {
        private readonly IColorDal colorDal;

        public ColorService(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public async Task<List<Color>> GetColorListAsync()
        {
            return await colorDal.GetList();
        }
    }
}
