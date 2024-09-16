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
    public class PhoneCaseService : IPhoneCaseService
    {
        private readonly IPhoneCasesDal phoneCasesDal;

        public PhoneCaseService(IPhoneCasesDal phoneCasesDal)
        {
            this.phoneCasesDal = phoneCasesDal;
        }

        public async Task Add(PhoneCase phoneCase)
        {
            await phoneCasesDal.Add(phoneCase);
        }

        public async Task Delete(int id)
        {
           var item=await phoneCasesDal.Get(p=>p.Id==id);
            await phoneCasesDal.Delete(item);

        }
         

        public async Task<List<PhoneCase>> GetAllCases()
        {
           return await phoneCasesDal.GetList();
        }

        public async Task<PhoneCase> GetById(int id)
        {
           return await phoneCasesDal.Get(p=>p.Id==id);
        }

        public async Task<List<PhoneCase>> GetCaseWithModelVendor(int vendorId = 0, int colorId = 0, int modelId = 0)
        {
           return await phoneCasesDal.GetCaseWithModelVendor(vendorId,colorId,modelId);
        }

        public async Task<List<PhoneCase>> GetSortedList(string value)
        {
            return await phoneCasesDal.GetSortedList(value);
        }

        public async Task Update(PhoneCase phoneCase)
        {
            await phoneCasesDal.Update(phoneCase);  
        }
    }
}
