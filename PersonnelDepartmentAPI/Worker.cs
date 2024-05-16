using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class Worker
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Patronymic { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? FamilyStatus { get; set; }

    public int? IdPost { get; set; }

    public int? IdRole { get; set; }

    public byte[]? Image { get; set; }

    public int? IdDirector { get; set; }

    public virtual Worker? IdDirectorNavigation { get; set; }

    public virtual Post? IdPostNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual InfoWorker? InfoWorker { get; set; }

    public virtual ICollection<Worker> InverseIdDirectorNavigation { get; set; } = new List<Worker>();

    public virtual ICollection<Omission> Omissions { get; set; } = new List<Omission>();

    public virtual ICollection<Sick> Sicks { get; set; } = new List<Sick>();

    public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();

    public virtual ICollection<Working> Workings { get; set; } = new List<Working>();
}
