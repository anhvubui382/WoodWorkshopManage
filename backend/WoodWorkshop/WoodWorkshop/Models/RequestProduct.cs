using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class RequestProduct
{
    public int RequestProductId { get; set; }

    public string? RequestProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? CompletionTime { get; set; }

    public int? RequestId { get; set; }

    public int? StatusId { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<ProcessProductError> ProcessProductErrors { get; set; } = new List<ProcessProductError>();

    public virtual ICollection<ProductRequestImage> ProductRequestImages { get; set; } = new List<ProductRequestImage>();

    public virtual ICollection<RequestImage> RequestImages { get; set; } = new List<RequestImage>();

    public virtual ICollection<RequestProductsSubmaterial> RequestProductsSubmaterials { get; set; } = new List<RequestProductsSubmaterial>();

    public virtual StatusProduct? Status { get; set; }
}
