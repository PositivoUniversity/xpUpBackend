using System.Security.Cryptography;

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

        MD5 md5Hash = MD5.Create();

        public string GetMd5Hash()
        {
            byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
