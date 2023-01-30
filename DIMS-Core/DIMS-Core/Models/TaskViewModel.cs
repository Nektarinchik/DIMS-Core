using System;

namespace DIMS_Core.Models;

public class TaskViewModel
{
    public int TaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? DeadlineDate { get; set; }
}