using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Job
{
    public int JobId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public string? Description { get; set; }

    public DateTime? TimeFinish { get; set; }

    public int? QuantityProduct { get; set; }

    public decimal? Cost { get; set; }

    public DateTime? TimeStart { get; set; }

    public string? Code { get; set; }

    public string? JobName { get; set; }

    public int? RequestProductId { get; set; }

    public int? OrderDetailId { get; set; }

    public int? StatusId { get; set; }

    public ulong? JobLog { get; set; }

    public ulong? Reassigned { get; set; }

    public int? OriginalQuantityProduct { get; set; }

    public virtual ICollection<Advancesalary> Advancesalaries { get; set; } = new List<Advancesalary>();

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual Orderdetail? OrderDetail { get; set; }

    public virtual ICollection<ProcessProductError> ProcessProductErrors { get; set; } = new List<ProcessProductError>();

    public virtual Product? Product { get; set; }

    public virtual RequestProduct? RequestProduct { get; set; }

    public virtual StatusJob? Status { get; set; }

    public virtual User? User { get; set; }
}
