using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

using ThreadingTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    /// <summary>
    ///     This class is unit of work pattern.
    ///     He is pretty popular in projects which have repository approach and using when you need to have access to many
    ///     repositories in one class under one context.
    ///     You can read about the pattern in Internet.
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DimsCoreContext _context;

        public UnitOfWork(DimsCoreContext context,
                          IRepository<UserProfile> userProfileRepository,
                          IRepository<Direction> directionRepository,
                          IRepository<TaskState> taskStateRepository,
                          IRepository<TaskTrack> taskTrackRepository,
                          IUserTaskRepository userTaskRepository,
                          IReadOnlyRepository<VUserTask> vUserTaskRepository,
                          IReadOnlyRepository<VUserProfile> vUserProfileRepository)
        {
            _context = context;

            UserProfileRepository  = userProfileRepository  ?? throw new ArgumentNullException(nameof(userProfileRepository));
            DirectionRepository    = directionRepository    ?? throw new ArgumentNullException(nameof(directionRepository));
            TaskStateRepository    = taskStateRepository    ?? throw new ArgumentNullException(nameof(taskStateRepository));
            TaskTrackRepository    = taskTrackRepository    ?? throw new ArgumentNullException(nameof(taskTrackRepository));
            UserTaskRepository     = userTaskRepository     ?? throw new ArgumentNullException(nameof(userTaskRepository));
            VUserTaskRepository    = vUserTaskRepository    ?? throw new ArgumentNullException(nameof(vUserTaskRepository));
            VUserProfileRepository = vUserProfileRepository ?? throw new ArgumentNullException(nameof(vUserProfileRepository));
        }

        public IRepository<UserProfile> UserProfileRepository { get; }

        public IRepository<Direction> DirectionRepository { get; }

        public IRepository<TaskState> TaskStateRepository { get; }

        public IRepository<TaskTrack> TaskTrackRepository { get; }

        public IUserTaskRepository UserTaskRepository { get; }


        public IReadOnlyRepository<VUserProfile> VUserProfileRepository { get; }
        public IReadOnlyRepository<VUserTask> VUserTaskRepository { get; }

        /// <summary>
        ///     This method is not important here because each repository already has same method.
        ///     But remember you can use repositories separately from unit of work. So 'Save' method exists in UnitOfWork and
        ///     Repository.
        /// </summary>
        /// <returns></returns>
        public async ThreadingTask SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}