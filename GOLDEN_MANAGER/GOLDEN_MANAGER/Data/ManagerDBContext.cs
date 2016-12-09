using GOLDEN_MANAGER.Models;
using System.Data.Entity;

namespace GOLDEN_MANAGER.Data
{
    public class ManagerDBContext : DbContext
    {
        public ManagerDBContext() 
            : base(nameOrConnectionString: "ManagerEntities") { }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}