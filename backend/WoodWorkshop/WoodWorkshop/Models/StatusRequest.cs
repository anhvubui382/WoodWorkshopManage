using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class StatusRequest
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
