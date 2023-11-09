
using System.Text.Json.Serialization;

namespace xpUpBackend.Dto
{
    public class CreateCoursesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public int? Enrolleds { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}
