using PhoneCaseEcommerce.Core.Concretes;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.DataAccess.Concretes
{
    public class ColorDal : EFEntityRepositoryBase<PhoneCaseEcommerceDbContext, Color>, IColorDal
    {
        public ColorDal(PhoneCaseEcommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
