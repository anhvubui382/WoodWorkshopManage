using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class ForgotPassword
{
    public int Fpid { get; set; }

    public DateTime? ExpirationTime { get; set; }

    public int? Otp { get; set; }

    public int? UserUserId { get; set; }

    public virtual User? UserUser { get; set; }
}
