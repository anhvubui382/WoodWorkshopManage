using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class EmployeeMaterial
{
    public int EmpMaterialId { get; set; }

    public int? EmployeeId { get; set; }

    public int? ProductSubMaterialId { get; set; }

    public int? RequestProductsSubmaterialsId { get; set; }

    public double? TotalMaterial { get; set; }

    public int? JobId { get; set; }

    public virtual User? Employee { get; set; }

    public virtual Job? Job { get; set; }

    public virtual ProductSubMaterial? ProductSubMaterial { get; set; }

    public virtual RequestProductsSubmaterial? RequestProductsSubmaterials { get; set; }
}
