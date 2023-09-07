using System.ComponentModel.DataAnnotations;

namespace xpUpBackend.Models
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Users Enrolleds { get; set; }

        public Courses() { }

        public Courses(int id, string name, Users enrolleds)
        {
            Id = id;
            Name = name;
            Enrolleds = enrolleds;
        }
    }
}
