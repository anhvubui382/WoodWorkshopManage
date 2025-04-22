using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class ProcessProductError
{
    public int ProcessProductErrorId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? IsFixed { get; set; }

    public string? Solution { get; set; }

    public int? JobId { get; set; }

    public int? ProductId { get; set; }

    public int? RequestProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Job? Job { get; set; }

    public virtual Product? Product { get; set; }

    public virtual RequestProduct? RequestProduct { get; set; }
}
