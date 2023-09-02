using System.ComponentModel.DataAnnotations;

namespace xpUpBackend.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public UsersRoles UserRole { get; set; }
        [Required]
        public Courses Course { get; set; }

        public Users(int id, string name, string email, UsersRoles userRole, Courses course)
        {
            Id = id;
            Name = name;
            Email = email;
            UserRole = userRole;
            Course = course;
        }
    }
}
