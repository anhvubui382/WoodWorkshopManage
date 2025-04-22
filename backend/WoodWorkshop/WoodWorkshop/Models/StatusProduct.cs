using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class StatusProduct
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public int? Type { get; set; }

    public string? Descriptions { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<RequestProduct> RequestProducts { get; set; } = new List<RequestProduct>();
}
