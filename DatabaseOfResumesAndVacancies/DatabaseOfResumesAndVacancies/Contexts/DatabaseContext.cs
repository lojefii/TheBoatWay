using DAL.Entities;
using System.Data.Entity;

namespace DAL.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DatabaseContext") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

    }
}