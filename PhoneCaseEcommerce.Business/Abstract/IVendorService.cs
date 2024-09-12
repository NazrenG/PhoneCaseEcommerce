using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.Business.Abstract
{
   public interface IVendorService
    {
        Task<List<Vendor>> GetAllVendor( ); 
    }
}
