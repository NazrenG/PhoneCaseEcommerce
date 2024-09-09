using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int PhoneCaseId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PhoneCase PhoneCase { get; set; } = null!;
}
