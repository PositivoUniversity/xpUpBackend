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
        [Required]
        [NotMapped]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        public string PasswordTip { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordTipHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Role { get; set; }
        public Courses? Course { get; set; }
        public List<Events>? Events { get; set; }
        public List<News>? News { get; set; }
    }
}
