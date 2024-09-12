using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.Business.Abstract
{
    public interface IPhoneCaseService
    {
        Task<List<PhoneCase>> GetAllCases();//lazim deyil
        Task<PhoneCase> GetById(int id);
        Task Add(PhoneCase phoneCase);
        Task Update(PhoneCase phoneCase);
        Task Delete(int id);

        Task<List<PhoneCase>> GetCaseWithModelVendor(int vendorId = 0);
        Task<List<PhoneCase>> FilterByVendorName(int vendorId);
    }
}
