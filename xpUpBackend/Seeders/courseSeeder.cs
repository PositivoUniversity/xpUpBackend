using Microsoft.EntityFrameworkCore;
using xpUpBackend.ContextDb;
using xpUpBackend.Models;

namespace xpUpBackend.seeder
{
    public class CourseSeeder : DbContext
    {
        public CourseSeeder(DbContextOptions<XpUpContext> options) : base(options)
        {
        }

        public DbSet<Courses> Courses { get; set; }

        public static void Initialize(XpUpContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Courses.Any())
            {
                var courseNamesToCreate = new string[]
          {
    "Administração",
    "Análise e Desenvolvimento de Sistemas",
    "Biomedicina",
    "Ciências Contábeis",
    "Direito",
    "Educação Física",
    "Enfermagem",
    "Fisioterapia",
    "Matemática",
    "Psicologia"
          };


                foreach (var courseName in courseNamesToCreate)
                {
                    var course = new Courses
                    {
                        Name = courseName
                    };

                    context.Courses.Add(course);
                }

                context.SaveChanges();
            }
        }
    }
}
