using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;

using ThreadingTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserProfile> UserProfileRepository { get; }
        IRepository<Direction> DirectionRepository { get; }
        IRepository<TaskState> TaskStateRepository { get; }
        IRepository<TaskTrack> TaskTrackRepository { get; }
        IRepository<UserTask> UserTaskRepository { get; }

        IReadOnlyRepository<VUserTask> VUserTaskRepository { get; }
        IReadOnlyRepository<VUserProfile> VUserProfileRepository { get; }
        ThreadingTask SaveAsync();
    }
}