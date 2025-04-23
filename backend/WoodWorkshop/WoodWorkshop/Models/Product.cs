using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int? StatusId { get; set; }

    public DateOnly? CompletionTime { get; set; }

    public int? CategoryId { get; set; }

    public DateOnly? EnddateWarranty { get; set; }

    public string? Code { get; set; }

    public int? Type { get; set; }

    public string? Image { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<ProcessProductError> ProcessProductErrors { get; set; } = new List<ProcessProductError>();

    public virtual ICollection<ProductSubMaterial> ProductSubMaterials { get; set; } = new List<ProductSubMaterial>();

    public virtual ICollection<Productimage> Productimages { get; set; } = new List<Productimage>();

    public virtual StatusProduct? Status { get; set; }

    public virtual ICollection<Whitelist> Whitelists { get; set; } = new List<Whitelist>();
}
