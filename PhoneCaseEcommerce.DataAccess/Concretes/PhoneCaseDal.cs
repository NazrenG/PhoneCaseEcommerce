using Microsoft.EntityFrameworkCore;
using PhoneCaseEcommerce.Core;
using PhoneCaseEcommerce.Core.Concretes;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCaseEcommerce.DataAccess.Concretes
{
    public class PhoneCaseDal : EFEntityRepositoryBase<PhoneCaseEcommerceDbContext, PhoneCase>, IPhoneCasesDal
    {
        private readonly PhoneCaseEcommerceDbContext _context;
        public PhoneCaseDal(PhoneCaseEcommerceDbContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<List<PhoneCase>> FilterByVendorName(int vendorId)
        {
           return await _context.PhoneCases.
                Include(m => m.Model).
                ThenInclude(v => v.Vendor).
                Where(l=>l.VendorId==vendorId).ToListAsync();
        }

        public async Task<List<PhoneCase>> GetCaseWithModelVendor(int vendorId=0)
        {
            if(vendorId==0)
           return await _context.PhoneCases.
                Include(p=>p.PhotoImages).
                Include(m=>m.Model).
                ThenInclude(v=>v.Vendor).ToListAsync();  
            else
                return await _context.PhoneCases.
                Include(p => p.PhotoImages).
                Include(m => m.Model).
                ThenInclude(v => v.Vendor).Where(i=>i.Id==vendorId).ToListAsync();
        }
    }
}
