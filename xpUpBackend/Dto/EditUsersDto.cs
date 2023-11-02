using System.Security.Cryptography;

namespace xpUpBackend.Dto
{
    public class EditUsersDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordTip { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordTipHash { get; set; }
        public int? Role { get; set; }
        public int Course { get; set; }
    }
}
