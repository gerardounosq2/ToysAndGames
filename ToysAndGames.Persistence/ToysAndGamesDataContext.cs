using Microsoft.EntityFrameworkCore;
using ToysAndGames.Domain.Models;

namespace ToysAndGames.Persistence
{
   public class ToysAndGamesDataContext : DbContext
   {
      public ToysAndGamesDataContext(DbContextOptions options)
         : base(options)
      {
      }

      public DbSet<Product> Products { get; set; }
      public DbSet<Company> Companies { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder
            .Entity<Product>()
            .HasKey(p => p.Id);

         modelBuilder
            .Entity<Product>()
            .Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();

         modelBuilder
            .Entity<Product>()
            .Property(r => r.Name)
            .HasMaxLength(100);

         modelBuilder
            .Entity<Product>()
            .Property(r => r.AgeRestriction);
      }
   }
}