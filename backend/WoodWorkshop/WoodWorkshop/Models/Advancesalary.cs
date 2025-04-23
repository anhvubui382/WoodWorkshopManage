using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Advancesalary
{
    public int AdvanceSalaryId { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Amount { get; set; }

    public int? UserId { get; set; }

    public ulong? IsAdvanceSuccess { get; set; }

    public string? Code { get; set; }

    public ulong? IsApprove { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? JobId { get; set; }

    public virtual Job? Job { get; set; }

    public virtual User? User { get; set; }
}
