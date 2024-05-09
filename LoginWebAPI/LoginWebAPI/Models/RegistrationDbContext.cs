using Microsoft.EntityFrameworkCore;

namespace LoginWebAPI.Models
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options)
        {
        }
        DbSet<Registration> registrations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Registration>().HasIndex(a => a.Email).IsUnique();
        }
    }
}
