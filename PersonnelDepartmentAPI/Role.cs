﻿using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleTitle { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
