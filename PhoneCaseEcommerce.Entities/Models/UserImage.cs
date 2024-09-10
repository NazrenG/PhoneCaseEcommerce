using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class UserImage
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Path { get; set; }
    //nav prop

    public virtual User User { get; set; } = null!;
}
