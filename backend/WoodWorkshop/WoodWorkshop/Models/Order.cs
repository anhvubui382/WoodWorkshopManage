using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? StatusId { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? SpecialOrder { get; set; }

    public int? PaymentMethod { get; set; }

    public decimal? Deposite { get; set; }

    public int? InforId { get; set; }

    public string? Code { get; set; }

    public virtual InformationUser? Infor { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<RequestImage> RequestImages { get; set; } = new List<RequestImage>();

    public virtual ICollection<RequestProduct> RequestProducts { get; set; } = new List<RequestProduct>();

    public virtual StatusOrder? Status { get; set; }
}
