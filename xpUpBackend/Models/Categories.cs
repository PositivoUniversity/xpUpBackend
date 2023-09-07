namespace xpUpBackend.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Courses RelatedCourses { get; set; }

        public Categories() { }

        public Categories(int id, string name, Courses relatedCourses)
        {
            Id = id;
            Name = name;
            RelatedCourses = relatedCourses;
        }
    }
}
