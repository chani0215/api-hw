using System;
using System.Collections.Generic;

namespace Ex3.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public int? Phone { get; set; }

    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
