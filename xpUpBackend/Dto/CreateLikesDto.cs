namespace xpUpBackend.Dto
{
    public class CreateLikesDto
    {
        public int Id { get; set; } 
        public bool Like { get; set; }
        public int LikedByUserId { get; set; } // ID do usuário que deu o like
        public int NoticeId { get; set; } // ID da notícia relacionada
        public int EventId { get; set; } // ID do evento relacionado
    }
}
