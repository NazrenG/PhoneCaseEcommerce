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
        //filter by model,vendor,color
        Task<List<PhoneCase>> GetCaseWithModelVendor(int vendorId = 0,int modelId=0,int colorId=0);
   // premium,popular ,best seller
        Task<List<PhoneCase>> GetSortedList(string value);
    }
}
