using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class Omission
{
    public int IdWorker { get; set; }

    public int? OmissionDay { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public int Id { get; set; }

    public virtual Worker IdWorkerNavigation { get; set; } = null!;
}
