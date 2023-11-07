namespace xpUpBackend.Dto
{
    public class CreateCheckinsDto
    {
        public int Id { get; set; }
        public bool Check { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CheckedById { get; set; } 
        public int? EventId { get; set; }    
    }
}
