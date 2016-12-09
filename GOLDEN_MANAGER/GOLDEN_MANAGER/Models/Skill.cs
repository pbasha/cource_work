
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEN_MANAGER.Models
{
    [Table("skills", Schema = "public")]
    public class Skill
    {
        [Key]
        [Column("skill_id")]
        public int skill_id { get; set; }
        [Column("user_id")]
        public int user_id { get; set; } = 1;
        [Column("skill_name")]
        public string skill_name { get; set; }
        [Column("skill_lvl")]
        public int skill_lvl { get; set; } = 0;
        [Column("skill_points")]
        public int skill_points { get; set; } = 0;
    }
}