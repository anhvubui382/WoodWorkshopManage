using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class InformationUser
{
    public int InforId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Fullname { get; set; }

    public string? Address { get; set; }

    public string? Bank { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? CityProvince { get; set; }

    public string? District { get; set; }

    public string? Wards { get; set; }

    public int? HasAccount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
