
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOLDEN_MANAGER.Models
{
    public class UserStats
    {
        [Key]
        public int us_id { get; set; }
        public int us_total_task_done { get; set; }
        public int us_total_points_got { get; set; }
        public List<User> us_friends { get; set; } = new List<User>();
    }
}