using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int PhoneCaseId { get; set; }

    public int UserId { get; set; }

    public virtual PhoneCase PhoneCase { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
