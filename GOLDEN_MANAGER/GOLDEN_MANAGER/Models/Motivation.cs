
using System;
using System.ComponentModel.DataAnnotations;

namespace GOLDEN_MANAGER.Models
{
    public class Motivation
    {
        [Key]
        public int mot_id { get; set; }
        public string mot_name { get; set; }
        public virtual User user { get; set; }
        public int mot_cash { get; set; }
        public Task task { get; set; }
        public DateTime mot_dead_line { get; set; }
    }
}