using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class PhoneColor
{
    public int Id { get; set; }

    public int PhoneCaseId { get; set; }

    public int ColorId { get; set; }
    //nav prop

    public virtual Color Color { get; set; } = null!;

    public virtual PhoneCase PhoneCase { get; set; } = null!;
}
