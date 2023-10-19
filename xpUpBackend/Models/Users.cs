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
        public string Email { get; set; }
        [Required]
        [NotMapped]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        public string PasswordTip { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [ForeignKey("UsersRoles")]
        public UsersRoles UserRole { get; set; }
        [ForeignKey("Courses")]
        public Courses Course { get; set; }
        public List<Events> Envents { get;  set; }
        public List<News> News { get; set; }
        public Users() {}

        public Users(string name, string email, string password, string passwordTip, UsersRoles userRole, Courses course)
        {
            Name = name;
            Email = email;
            Password = password;
            PasswordTip = passwordTip;
            UserRole = userRole;
            Course = course;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
