using Microsoft.EntityFrameworkCore;
using xpUpBackend.Models;

namespace xpUpBackend.ContextDb
{
    public class XpUpContext : DbContext
    {
        public XpUpContext(DbContextOptions<XpUpContext> options) : base(options) { }
        public DbSet<Users>? Users { get; set; }
        public DbSet<News>? News { get; set; }
        public DbSet<Likes>? Likes { get; set; }
        public DbSet<Events>? Events { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CheckIn>? CheckIn { get; set; }
    }
}
