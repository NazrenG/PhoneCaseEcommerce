using Microsoft.EntityFrameworkCore;
using PhoneCaseEcommerce.Core.Concretes;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.DataAccess.Concretes
{
    public class PhoneCaseDal : EFEntityRepositoryBase<PhoneCaseEcommerceDbContext, PhoneCase>, IPhoneCasesDal
    {
        private readonly PhoneCaseEcommerceDbContext _context;
        public PhoneCaseDal(PhoneCaseEcommerceDbContext context) : base(context)
        {
            _context = context;
        }
         
        public async Task<List<PhoneCase>> GetCaseWithModelVendor(int vendorId = 0, int colorId = 0, int modelId = 0)
        {
            var query = _context.PhoneCases
           .Include(p => p.PhoneCaseImages)
           .Include(m => m.Model)
           .ThenInclude(v => v.Vendor)
           .Include(pc => pc.PhoneColors)
           .ThenInclude(c => c.Color)
           .AsQueryable();
             

            if (vendorId != 0)
            {
                query = query.Where(pc => pc.VendorId == vendorId);
            }
            if (colorId != 0)
            {
                query = query.Where(pc => pc.PhoneColors.Any(c => c.ColorId == colorId));
            }
            if (modelId != 0)
            {
                query = query.Where(pc => pc.ModelId == modelId);
            }

            return await query.ToListAsync();


        }
        

        public async Task<List<PhoneCase>> GetSortedList(string value)
        {
            return await _context.PhoneCases.Where(p => p.Premium == value)
                   .Include(p => p.PhoneCaseImages)
              .Include(m => m.Model)
              .ThenInclude(v => v.Vendor)
              .Include(pc => pc.PhoneColors)
              .ThenInclude(c => c.Color).Take(4).ToListAsync();
        }
   
    
    
    }
}
