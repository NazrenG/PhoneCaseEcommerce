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
    public class VendorService : IVendorService
    {
        private readonly IVendorDal vendorDal;

        public VendorService(IVendorDal vendorDal)
        {
            this.vendorDal = vendorDal;
        }

        public async Task<List<Vendor>> GetAllVendor()
        {
           return await vendorDal.GetList();
        }
    }
}
