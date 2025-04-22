using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class ProductSubMaterial
{
    public int ProductSubMaterialId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Quantity { get; set; }

    public int? InputId { get; set; }

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual Product? Product { get; set; }
}
