using PhoneCaseEcommerce.Core.Abstract;
using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class Vendor:IEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }
    //nav prop
    public virtual ICollection<Model> Models { get; set; } = new List<Model>();

    public virtual ICollection<PhoneCase> PhoneCases { get; set; } = new List<PhoneCase>();
}
