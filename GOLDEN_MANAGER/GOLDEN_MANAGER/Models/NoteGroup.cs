using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOLDEN_MANAGER.Models
{
    public class NoteGroup
    {
        [Key]
        public int np_id { get; set; }
        public string np_name { get; set; }
        public string np_description { get; set; }
        public int np_priority { get; set; }
        public List<Note> np_notes { get; set; } = new List<Note>();
    }
}