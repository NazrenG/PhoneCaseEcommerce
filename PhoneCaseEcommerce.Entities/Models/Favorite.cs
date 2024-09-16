using PhoneCaseEcommerce.Core.Abstract;
using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class Favorite:IEntity
{
    public int Id { get; set; }
    public int UserId {  get; set; }
    public int PhoneCaseId { get; set; }
    //nav prop
    public virtual User User { get; set; } = null!;
    public virtual PhoneCase PhoneCase { get; set; } = null!;
}
