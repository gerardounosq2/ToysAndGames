using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

         modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

         modelBuilder.Seed();


      }
   }
}