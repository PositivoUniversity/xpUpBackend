using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpUpBackend.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordTip { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Role { get; set; }
        public Courses? Course { get; set; }
        [NotMapped]
        public List<Events>? Events { get; set; }
        [NotMapped]
        public List<News>? News { get; set; }
    }
}
