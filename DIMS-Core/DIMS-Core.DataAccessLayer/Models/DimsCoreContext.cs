using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Models
{
    public class DimsCoreContext : DbContext
    {
        public DimsCoreContext()
        {
        }

        public DimsCoreContext(DbContextOptions<DimsCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<VUserProfile> VUserProfiles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskState> TaskStates { get; set; }
        public virtual DbSet<TaskTrack> TaskTracks { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }
        public virtual DbSet<VTask> VTasks { get; set; }
        public virtual DbSet<VUserProgress> VUserProgresses { get; set; }
        public virtual DbSet<VUserTask> VUserTasks { get; set; }
        public virtual DbSet<VUserTrack> VUserTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>(entity =>
            {
                entity.Property(e => e.Description)
                        .HasMaxLength(250);

                entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4C01393682");

                entity.Property(e => e.Address)
                    .HasMaxLength(120);

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date");

                entity.Property(e => e.Education)
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype)
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date");

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.DirectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserProfi__Direc__38996AB5");
            });

            modelBuilder.Entity<VUserProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserProfiles");

                entity.Property(e => e.Address)
                    .HasMaxLength(120);

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Education)
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype)
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.DeadlineDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<TaskState>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("PK_TaskState_StateId");

                entity.ToTable("TaskState");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<TaskTrack>(entity =>
            {
                entity.ToTable("TaskTrack");

                entity.Property(e => e.TrackDate).HasColumnType("date");

                entity.Property(e => e.TrackNote)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.UserTask)
                    .WithMany(p => p.TaskTracks)
                    .HasForeignKey(d => d.UserTaskId)
                    .HasConstraintName("FK_TaskTrack_UseTask_UserTaskId");
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.ToTable("UserTask");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.StateId);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_UserTask_Task_TaskId");
            });

            modelBuilder.Entity<VTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vTasks");

                entity.Property(e => e.DeadlineDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TaskId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VUserProgress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserProgress");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrackDate).HasColumnType("date");

                entity.Property(e => e.TrackNote)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(101);
            });

            modelBuilder.Entity<VUserTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserTask");

                entity.Property(e => e.DeadlineDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<VUserTrack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserTrack");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrackDate).HasColumnType("date");

                entity.Property(e => e.TrackNote)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}