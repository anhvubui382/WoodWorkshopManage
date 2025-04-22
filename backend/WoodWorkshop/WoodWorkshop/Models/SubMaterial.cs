using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class SubMaterial
{
    public int SubMaterialId { get; set; }

    public string? SubMaterialName { get; set; }

    public int? MaterialId { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<InputSubMaterial> InputSubMaterials { get; set; } = new List<InputSubMaterial>();

    public virtual Material? Material { get; set; }
}
