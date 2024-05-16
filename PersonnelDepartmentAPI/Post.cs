using System;
using System.Collections.Generic;

namespace PersonnelDepartmentAPI;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal? Salary { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
