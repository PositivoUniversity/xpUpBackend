namespace xpUpBackend.Models
{
    public class News
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public Users CreatedAt { get; set; }

        public News() { }

        public News(int id, DateTime publishDate, Users createdAt)
        {
            Id = id;
            PublishDate = publishDate;
            CreatedAt = createdAt;
        }
    }
}
