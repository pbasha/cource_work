using GOLDEN_MANAGER.Models;
using System.Data.Entity;

namespace GOLDEN_MANAGER.Data
{
    public class ManagerDBContext : DbContext
    {
        public ManagerDBContext(){ }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Motivation> Motiations { get; set; }
        public DbSet<NoteGroup> NoteGroups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserStats> UsersStats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                    .HasRequired<NoteGroup>(s => s.noteGroup)
                    .WithMany(s => s.np_notes);

            modelBuilder.Entity<User>()
                    .HasRequired<UserGroup>(s => s.userGroup)
                    .WithMany(s => s.ug_users);

            modelBuilder.Entity<Task>()
                .HasMany(m => m.task_days_durations)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("TaskDayRelation");
                    m.MapLeftKey("day_id");
                    m.MapRightKey("task_id");
                });

            modelBuilder.Entity<Task>()
                .HasMany(m => m.task_bonuses)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("TaskBonusRelation");
                    m.MapLeftKey("bonus_id");
                    m.MapRightKey("task_id");
                });

        }
    }
}