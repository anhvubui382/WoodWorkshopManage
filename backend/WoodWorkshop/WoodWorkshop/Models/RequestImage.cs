using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class RequestImage
{
    public int ProductImageId { get; set; }

    public string? ExtensionName { get; set; }

    public string? FileOriginalName { get; set; }

    public string? FullPath { get; set; }

    public string? Image { get; set; }

    public int? RequestId { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual RequestProduct? Request { get; set; }
}
