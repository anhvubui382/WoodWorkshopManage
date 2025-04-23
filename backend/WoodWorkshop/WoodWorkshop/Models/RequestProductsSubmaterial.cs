using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class RequestProductsSubmaterial
{
    public int RequestProductsSubmaterialsId { get; set; }

    public int? RequestProductId { get; set; }

    public int? SubMaterialId { get; set; }

    public double? Quantity { get; set; }

    public int? InputId { get; set; }

    public int SubMaterial { get; set; }

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual InputSubMaterial? Input { get; set; }

    public virtual RequestProduct? RequestProduct { get; set; }
}
