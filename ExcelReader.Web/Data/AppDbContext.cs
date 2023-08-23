using ExcelReader.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExcelReader.Web.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
