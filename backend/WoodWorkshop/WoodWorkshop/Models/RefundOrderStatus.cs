using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class RefundOrderStatus
{
    public int RefundId { get; set; }

    public string? RefundName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
