using Microsoft.EntityFrameworkCore;
using xpUpBackend.Models;

namespace xpUpBackend.ContextDb
{
    public class XpUpContext : DbContext
    {
        public XpUpContext(DbContextOptions<XpUpContext> options) : base(options) { }
        public DbSet<xpUpBackend.Models.Users>? Users { get; set; }
        public DbSet<xpUpBackend.Models.News>? News { get; set; }
        public DbSet<xpUpBackend.Models.Likes>? Likes { get; set; }
        public DbSet<xpUpBackend.Models.Events>? Events { get; set; }
        public DbSet<xpUpBackend.Models.Courses>? Courses { get; set; }
        public DbSet<xpUpBackend.Models.CheckIn>? CheckIn { get; set; }
    }
}
