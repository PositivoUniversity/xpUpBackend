using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpUpBackend.Models
{
    public class CheckIn
    {
        [Key]
        public int Id { get; set; }
        public bool Check { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [ForeignKey("Users")]
        public Users CheckedBy { get; set; }
        [ForeignKey("Events")]
        public Events Event { get; set; }

        public CheckIn() { }

        public CheckIn(bool check, Users checkedBy, Events events)
        {
            Check = check;
            CheckedBy = checkedBy;
            Event = events;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
