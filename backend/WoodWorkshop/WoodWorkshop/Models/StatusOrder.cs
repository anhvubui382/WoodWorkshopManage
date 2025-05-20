using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class StatusOrder
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
