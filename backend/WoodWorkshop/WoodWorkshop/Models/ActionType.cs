using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class ActionType
{
    public int ActionTypeId { get; set; }

    public string? ActionName { get; set; }

    public virtual ICollection<InputSubMaterial> InputSubMaterials { get; set; } = new List<InputSubMaterial>();
}
