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
        Task<List<PhoneCase>> GetCaseWithModelVendor(int vendorId=0);
        Task<List<PhoneCase>> FilterByVendorName(int vendorId);
    }
}
