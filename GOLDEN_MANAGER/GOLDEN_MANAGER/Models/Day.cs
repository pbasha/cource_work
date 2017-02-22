using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOLDEN_MANAGER.Models
{
    public class Day
    {
        [Key]
        public int day_id { get; set; }
        public string day_name { get; set; }
        public string day_description { get; set; }
        public virtual User user { get; set; }
        public DateTime day_date { get; set; }
        public List<Task> day_task_list { get; set; } = new List<Task>();
    }
}