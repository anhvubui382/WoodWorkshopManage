using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class StatusJob
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public int? Type { get; set; }

    public string? Des { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
