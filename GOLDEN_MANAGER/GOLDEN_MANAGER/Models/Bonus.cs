using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEN_MANAGER.Models
{
    [Table("bonuses", Schema = "public")]
    public class Bonus
    {
        [Key]
        [Column("bonus_id")]
        public int bonus_id { get; set; }
        [Column("bonus_name")]
        public string bonus_name { get; set; }
        [Column("bonus_description")]
        public string bonus_description { get; set; }
        [Column("bonus_pma")]
        public int bonus_points_must_achieve { get; set; }
        [Column("user_id")]
        public int user_id { get; set; }
    }
}