using PhoneCaseEcommerce.Core.Abstract;
using System;
using System.Collections.Generic;
 
namespace PhoneCaseEcommerce.Entities.Models;

public partial class PhoneCase: IEntity
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int? SellCount { get; set; }

    public string Premium { get; set; } = null!;

    public int VendorId { get; set; }

    public int ModelId { get; set; }

    public int UserId { get; set; }


    //nav prop
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual Model Model { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PhoneColor> PhoneColors { get; set; } = new List<PhoneColor>();

    public virtual ICollection<PhoneCaseImage> PhoneCaseImages { get; set; } = new List<PhoneCaseImage>();

    public virtual User User { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}
