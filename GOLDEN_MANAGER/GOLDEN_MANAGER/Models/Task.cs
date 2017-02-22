using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEN_MANAGER.Models
{
    public class Task
    {
        [Key]
        public int task_id { get; set; }
        public string task_name { get; set; }
        public int task_priority { get; set; }
        public int task_achiv_points { get; set; }
        public string task_description { get; set; }
        public virtual User user { get; set; }
        public List<Day> task_days_durations { get; set; } = new List<Day>();
        public List<Bonus> task_bonuses { get; set; } = new List<Bonus>();
    }
}