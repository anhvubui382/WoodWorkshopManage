using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class ProductSubMaterial
{
    public int ProductSubMaterialId { get; set; }

    public int? SubMaterialId { get; set; }

    public int? ProductId { get; set; }

    public double? Quantity { get; set; }

    public int? InputId { get; set; }

    public int SubMaterial { get; set; }

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual InputSubMaterial? Input { get; set; }

    public virtual Product? Product { get; set; }
}
