using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOLDEN_MANAGER.Models
{
    public class Bonus
    {
        [Key]
        public int bonus_id { get; set; }
        public string bonus_name { get; set; }
        public string bonus_description { get; set; }
        public int bonus_points_must_achieve { get; set; }
        public virtual User user { get; set; }
        public List<Task> bonus_for_tasks { get; set; } = new List<Task>();
    }
}