using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class StatusUser
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
