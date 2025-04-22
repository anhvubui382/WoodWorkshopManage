using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Position
{
    public int PositionId { get; set; }

    public string? PositionName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
