using PhoneCaseEcommerce.Core;
using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.DataAccess.Abstract
{
    public interface IPhoneCasesDal : IEntityRepository<PhoneCase>
    {
        //filter by model,vendor,color
        Task<List<PhoneCase>> GetCaseWithModelVendor(int vendorId=0,int colorId=0,int modelId=0);
        // premium,popular ,best seller
        Task<List<PhoneCase>> GetSortedList(string value); 
    }
}
