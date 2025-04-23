using System;
using System.Collections.Generic;

namespace WoodWorkshop.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? RoleId { get; set; }

    public int? StatusId { get; set; }

    public DateOnly? HireDate { get; set; }

    public int? InforId { get; set; }

    public int? PositionId { get; set; }

    public virtual ICollection<Advancesalary> Advancesalaries { get; set; } = new List<Advancesalary>();

    public virtual ICollection<EmployeeMaterial> EmployeeMaterials { get; set; } = new List<EmployeeMaterial>();

    public virtual ForgotPassword? ForgotPassword { get; set; }

    public virtual InformationUser? Infor { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual Position? Position { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    public virtual StatusUser? Status { get; set; }

    public virtual ICollection<Whitelist> Whitelists { get; set; } = new List<Whitelist>();
}
