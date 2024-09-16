using Microsoft.EntityFrameworkCore;
using PhoneCaseEcommerce.Core.Concretes;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.DataAccess.Concretes
{
    public class FavDal : EFEntityRepositoryBase<PhoneCaseEcommerceDbContext, Favorite>, IFavDal
    {
        private readonly PhoneCaseEcommerceDbContext _context;
        public FavDal(PhoneCaseEcommerceDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Favorite>> GetAllFav()
        {
           return await _context.Favorites.
                Include(u=>u.User).
                Include(c=>c.PhoneCase).
                ThenInclude(p => p.PhoneCaseImages).
                  Include(c => c.PhoneCase).
           ThenInclude(m => m.Model)
           .ThenInclude(v => v.Vendor)
                .ToListAsync();
        }
    }
}
