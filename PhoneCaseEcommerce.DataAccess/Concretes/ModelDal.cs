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
    public class ModelDal : EFEntityRepositoryBase<PhoneCaseEcommerceDbContext, Model>, IModelDal
    {
        public ModelDal(PhoneCaseEcommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
