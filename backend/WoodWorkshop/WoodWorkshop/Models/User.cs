using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public int? StatusId { get; set; }

    public DateOnly? HireDate { get; set; }

    public int? InforId { get; set; }

    public int? PositionId { get; set; }

    public virtual ICollection<Advancesalary> Advancesalaries { get; set; } = new List<Advancesalary>();

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual ICollection<ForgotPassword> ForgotPasswords { get; set; } = new List<ForgotPassword>();

    public virtual InformationUser? Infor { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual Position? Position { get; set; }

    public virtual Role? Role { get; set; }

    public virtual StatusUser? Status { get; set; }

    public virtual ICollection<Whitelist> Whitelists { get; set; } = new List<Whitelist>();
}
