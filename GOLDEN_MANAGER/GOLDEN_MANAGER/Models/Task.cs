using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEN_MANAGER.Models
{
    [Table("tasks", Schema = "public")]
    public class Task
    {
        [Key]
        [Column("task_id")]
        public int task_id { get; set; }
        [Column("task_name")]
        public string task_name { get; set; }
        [Column("task_priority")]
        public int task_priority { get; set; }
        [Column("task_achiv_points")]
        public int task_achiv_points { get; set; }
        [Column("task_description")]
        public string task_description { get; set; }
        [Column("user_id")]
        public int user_id { get; set; }
    }
}