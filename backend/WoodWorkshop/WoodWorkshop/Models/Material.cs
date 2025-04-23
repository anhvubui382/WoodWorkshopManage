using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Material
{
    public int MaterialId { get; set; }

    public string MaterialName { get; set; } = null!;

    public string? Type { get; set; }

    public virtual ICollection<SubMaterial> SubMaterials { get; set; } = new List<SubMaterial>();
}
