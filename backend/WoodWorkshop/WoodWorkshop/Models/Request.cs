using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public int? UserId { get; set; }

    public DateTime? RequestDate { get; set; }

    public int? StatusId { get; set; }

    public string? Response { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public string? Address { get; set; }

    public string? Fullname { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CityProvince { get; set; }

    public string? District { get; set; }

    public string? Wards { get; set; }

    public string? Email { get; set; }

    public virtual StatusRequest? Status { get; set; }

    public virtual User? User { get; set; }
}
