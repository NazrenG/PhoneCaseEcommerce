using PhoneCaseEcommerce.Core.Abstract;
using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class Model:IEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int VendorId { get; set; }

    //nav prop

    public virtual ICollection<PhoneCase> PhoneCases { get; set; } = new List<PhoneCase>();

    public virtual Vendor Vendor { get; set; } = null!;
}
