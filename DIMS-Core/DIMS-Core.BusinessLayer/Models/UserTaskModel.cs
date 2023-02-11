using System.Collections.Generic;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Models;

public class UserTaskModel
{
    public UserTaskModel()
    {
        TaskTracks = new HashSet<TaskTrackModel>();
    }

    public int UserTaskId { get; set; }
    public int TaskId { get; set; }
    public int UserId { get; set; }
    public int StateId { get; set; }

    public virtual TaskState State { get; set; }
    public virtual Task Task { get; set; }
    public virtual ICollection<TaskTrackModel> TaskTracks { get; set; }
}