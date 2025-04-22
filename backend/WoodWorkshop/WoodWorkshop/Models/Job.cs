using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class Job
{
    public int JobId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public string? Description { get; set; }

    public int? StatusId { get; set; }

    public int? JobIdParent { get; set; }

    public virtual ICollection<Advancesalary> Advancesalaries { get; set; } = new List<Advancesalary>();

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual ICollection<Job> InverseJobIdParentNavigation { get; set; } = new List<Job>();

    public virtual Job? JobIdParentNavigation { get; set; }

    public virtual ICollection<ProcessProductError> ProcessProductErrors { get; set; } = new List<ProcessProductError>();

    public virtual Product? Product { get; set; }

    public virtual StatusJob? Status { get; set; }

    public virtual User? User { get; set; }
}
