using System.ComponentModel.DataAnnotations.Schema;

namespace xpUpBackend.Dto
{
    public class CreateLikesDto
    {
        public int Id { get; set; } 
        public bool Like { get; set; }
        public int LikedByUserId { get; set; }
        public int? NoticeId { get; set; } 
        public int? EventId { get; set; } 
    }
}
