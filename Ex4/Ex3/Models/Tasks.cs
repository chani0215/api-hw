using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ex3.Models;

public partial class Tasks
{
    [Key]
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public int? Status { get; set; }

    public int UserId { get; set; }

    public int ProjectId { get; set; }

    //public virtual Project Project { get; set; } = null!;

    //public virtual User User { get; set; } = null!;
}
