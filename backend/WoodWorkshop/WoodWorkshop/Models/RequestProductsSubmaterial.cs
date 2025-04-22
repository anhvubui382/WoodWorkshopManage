using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class RequestProductsSubmaterial
{
    public int RequestProductsSubmaterialsId { get; set; }

    public int? RequestProductId { get; set; }

    public decimal? Quantity { get; set; }

    public int? InputId { get; set; }

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual RequestProduct? RequestProduct { get; set; }
}
