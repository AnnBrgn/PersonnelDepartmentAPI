﻿using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
