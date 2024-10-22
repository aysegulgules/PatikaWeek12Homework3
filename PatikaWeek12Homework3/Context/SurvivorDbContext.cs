using Microsoft.EntityFrameworkCore;
using PatikaWeek12Homework3.Entities;


public class SurvivorDbContext : DbContext
{
  
    public DbSet<CompetitorEntity> Competitors { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server=LAPTOP-748G4HT2;database=PatikaCodeFirstDb2;Trusted_Connection=true;TrustServerCertificate=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.Competitors)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId);
    }
}