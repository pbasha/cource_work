
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEN_MANAGER.Models
{
    public class Skill
    {
        [Key]
        public int skill_id { get; set; }
        public virtual User user { get; set; }
        public string skill_name { get; set; }
        public int skill_lvl { get; set; } = 0;
        public int skill_points { get; set; } = 0;
    }
}