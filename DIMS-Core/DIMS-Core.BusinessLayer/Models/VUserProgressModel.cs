using System;

namespace DIMS_Core.BusinessLayer.Models;

public class VUserProgressModel
{
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public int TaskTrackId { get; set; }
    public string UserName { get; set; }
    public string TaskName { get; set; }
    public string TrackNote { get; set; }
    public DateTime TrackDate { get; set; }
}