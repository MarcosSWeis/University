using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAcces
{
    //este es el contexto de mi base de datos
    //este UniversityContext va a extender de DbContext de EntityFramework
    public class UniversityContext : DbContext
    {
        //constructor de mi UniversityContext
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {

        }

        //TODO ADD DBsets  (tables of our data base)
        //lo que hace es basicamente es crearme las tablas en la base de datos que especificamos antes en el appsettings
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }


    }
}
