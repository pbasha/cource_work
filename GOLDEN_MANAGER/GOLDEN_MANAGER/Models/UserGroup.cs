using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOLDEN_MANAGER.Models
{
    public class UserGroup
    {
        [Key]
        public int ug_id { get; set; }
        public string ug_name { get; set; }
        public string ug_description { get; set; }
        public List<User> ug_users { get; set; } = new List<User>();
    }
}