using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class InputSubMaterial
{
    public int InputId { get; set; }

    public DateTime? DateInput { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? SubMaterialId { get; set; }

    public int? ActionTypeId { get; set; }

    public decimal? OutPrice { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CodeInput { get; set; }

    public virtual ActionType? ActionType { get; set; }

    public virtual SubMaterial? SubMaterial { get; set; }
}
