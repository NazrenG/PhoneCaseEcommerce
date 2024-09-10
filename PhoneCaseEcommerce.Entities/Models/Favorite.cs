﻿using System;
using System.Collections.Generic;

namespace PhoneCaseEcommerce.Entities.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int PhoneCaseId { get; set; }
    //nav prop
    public virtual PhoneCase PhoneCase { get; set; } = null!;
}
