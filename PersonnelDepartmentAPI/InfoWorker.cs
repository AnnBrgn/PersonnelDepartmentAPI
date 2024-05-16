using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class InfoWorker
{
    public int IdWorker { get; set; }

    public string? SeriesPassport { get; set; }

    public string? NumberPassport { get; set; }

    public string? Snils { get; set; }

    public string? NumberPhone { get; set; }

    public string? Education { get; set; }

    public string? Inn { get; set; }

    public virtual Worker IdWorkerNavigation { get; set; } = null!;
}
