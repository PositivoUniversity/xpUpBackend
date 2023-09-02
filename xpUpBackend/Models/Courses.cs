using System.ComponentModel.DataAnnotations;

namespace xpUpBackend.Models
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Courses(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
