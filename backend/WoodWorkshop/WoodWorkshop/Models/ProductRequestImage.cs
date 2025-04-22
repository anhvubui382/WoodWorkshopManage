using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class ProductRequestImage
{
    public int ProductImageId { get; set; }

    public string? ExtensionName { get; set; }

    public string? FileOriginalName { get; set; }

    public string? FullPath { get; set; }

    public string? Image { get; set; }

    public int? RequestProductId { get; set; }

    public virtual RequestProduct? RequestProduct { get; set; }
}
