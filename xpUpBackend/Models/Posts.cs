namespace xpUpBackend.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public Users CreatedAt { get; set; }

        public Posts() { }

        public Posts(int id, DateTime publishDate, Users createdAt)
        {
            Id = id;
            PublishDate = publishDate;
            CreatedAt = createdAt;
        }
    }
}
