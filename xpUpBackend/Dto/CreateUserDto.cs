namespace xpUpBackend.Dto
{
    public class CreateUsersDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordTip { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordTipHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Role { get; set; }
        public int Course { get; set; }
    }
}