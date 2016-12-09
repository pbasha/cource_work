using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEN_MANAGER.Models
{
    [Table("notes", Schema = "public")]
    public class Note
    {
        [Key]
        [Column("note_id")]
        public int note_id { get; set; }
        [Column("user_id")]
        public int user_id { get; set; }
        [Column("group_notes_id")]
        public int group_notes_id { get; set; }
        [Column("note_name")]
        public string note_name { get; set; }
        [Column("note_description")]
        public string note_description { get; set; }
        //[Column("note_alarm_date")]
        //public int MyProperty { get; set; }
        [Column("note_priority")]
        public int note_priority { get; set; }
    }
}