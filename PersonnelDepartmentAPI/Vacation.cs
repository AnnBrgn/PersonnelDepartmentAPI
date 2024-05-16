using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class Vacation
{
    public int IdWorker { get; set; }

    public int? VacationDay { get; set; }

    public DateTime? Date { get; set; }

    public int Id { get; set; }

    public virtual Worker IdWorkerNavigation { get; set; } = null!;
}
