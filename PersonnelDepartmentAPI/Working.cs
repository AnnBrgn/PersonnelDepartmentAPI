using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class Working
{
    public int IdWorker { get; set; }

    public int? WorkingDay { get; set; }

    public DateTime? Date { get; set; }

    public int? CountHours { get; set; }

    public int Id { get; set; }

    public virtual Worker IdWorkerNavigation { get; set; } = null!;
}
