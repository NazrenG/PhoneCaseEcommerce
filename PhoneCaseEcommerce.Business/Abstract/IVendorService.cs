﻿using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.Business.Abstract
{
    public interface IVendorService
    {
        Task<List<Vendor>> GetAllVendor( ); 
    }
}
