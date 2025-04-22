using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Whitelist
{
    public long Id { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
