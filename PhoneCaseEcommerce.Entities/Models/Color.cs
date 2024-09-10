using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class Color
{
    public int Id { get; set; }

    public string? Name { get; set; }
    //navigation prop
    public virtual ICollection<PhoneColor> PhoneColors { get; set; } = new List<PhoneColor>();
}
