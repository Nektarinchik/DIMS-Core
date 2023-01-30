using System;

namespace DIMS_Core.BusinessLayer.Models;

public class VUserTaskModel
{
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? DeadlineDate { get; set; }
    public string StateName { get; set; }
}