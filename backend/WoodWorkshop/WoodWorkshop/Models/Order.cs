using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? StatusId { get; set; }

    public decimal? TotalAmount { get; set; }

    public ulong? SpecialOrder { get; set; }

    public int? PaymentMethod { get; set; }

    public decimal? Deposite { get; set; }

    public int? InforId { get; set; }

    public string? Code { get; set; }

    public string? Address { get; set; }

    public string? Fullname { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CityProvince { get; set; }

    public string? District { get; set; }

    public string? Wards { get; set; }

    public DateTime? OrderFinish { get; set; }

    public string? Description { get; set; }

    public string? Response { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Refund { get; set; }

    public DateTime? ContractDate { get; set; }

    public int? RefundId { get; set; }

    public virtual InformationUser? Infor { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual RefundOrderStatus? RefundNavigation { get; set; }

    public virtual ICollection<RequestImage> RequestImages { get; set; } = new List<RequestImage>();

    public virtual ICollection<RequestProduct> RequestProducts { get; set; } = new List<RequestProduct>();

    public virtual StatusOrder? Status { get; set; }
}
