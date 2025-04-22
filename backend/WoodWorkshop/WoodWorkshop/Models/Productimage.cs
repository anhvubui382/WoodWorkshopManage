using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Productimage
{
    public int ProductImageId { get; set; }

    public int? ProductId { get; set; }

    public string? ExtensionName { get; set; }

    public string? FileOriginalName { get; set; }

    public string? FullPath { get; set; }

    public string? Image { get; set; }

    public virtual Product? Product { get; set; }
}
