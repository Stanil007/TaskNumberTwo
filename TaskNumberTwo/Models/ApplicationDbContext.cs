using Microsoft.EntityFrameworkCore;
using TaskNumberTwo.Models.Configurations;

namespace TaskNumberTwo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new HouseConfiguration());
            builder.ApplyConfiguration(new FlatConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());

            builder.Entity<Person>()
                .HasMany(p => p.Flats)
                .WithMany(h => h.Persons);

            builder.Entity<House>()
                .HasMany(h => h.Flats)
                .WithOne(f => f.House);

            base.OnModelCreating(builder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
