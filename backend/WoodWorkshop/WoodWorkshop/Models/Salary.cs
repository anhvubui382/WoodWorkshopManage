using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public int? UserId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? Date { get; set; }

    public virtual User? User { get; set; }
}
