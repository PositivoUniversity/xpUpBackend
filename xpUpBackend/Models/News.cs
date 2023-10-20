using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpUpBackend.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [ForeignKey("Users")]
        public int  PublishedBy { get; set; }

        public Users user { get; set; }

        public News() { }

        public News(string title, string subtitle, string description, int publishedBy)
        {
            Title = title;
            Subtitle = subtitle;
            Description = description;
            PublishedBy = publishedBy;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
