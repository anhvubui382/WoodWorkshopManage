using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Suppliermaterial
{
    public int SupplierMaterial1 { get; set; }

    public string? SupplierName { get; set; }

    public string? PhoneNumber { get; set; }

    public int? SubMaterialId { get; set; }

    public virtual SubMaterial? SubMaterial { get; set; }
}
