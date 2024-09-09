using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class PhotoImage
{
    public int Id { get; set; }

    public int PhoneCaseId { get; set; }

    public string? Path { get; set; }

    public virtual PhoneCase PhoneCase { get; set; } = null!;
}
