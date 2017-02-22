using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOLDEN_MANAGER.Models
{
    public class Note
    {
        [Key]
        public int note_id { get; set; }
        public virtual User user { get; set; }
        public int group_notes_id { get; set; }
        public string note_name { get; set; }
        public string note_description { get; set; }
        public int note_priority { get; set; }
        public virtual NoteGroup noteGroup { get; set; }
    }
}