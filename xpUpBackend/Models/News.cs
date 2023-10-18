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
        public Users PublishedBy { get; set; }
        public List<Likes> Likes { get; private set; }

        public News() 
        {
            Likes = new List<Likes>();
        }

        public News(string title, string subtitle, string description, Users publishedBy)
        {
            Title = title;
            Subtitle = subtitle;
            Description = description;
            PublishedBy = publishedBy;
            Likes = new List<Likes>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now; 
        }
    }
}
