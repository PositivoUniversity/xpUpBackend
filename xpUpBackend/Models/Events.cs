using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpUpBackend.Models
{
    public class Events
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
        public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>(); 
        public ICollection<Likes> Likes { get; set; } = new List<Likes>();
        public Events() { }
        
        public Events(string title, string subtitle, string description, Users publishedBy)
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
