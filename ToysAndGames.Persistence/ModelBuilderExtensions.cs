using Microsoft.EntityFrameworkCore;
using ToysAndGames.Domain.Models;

namespace ToysAndGames.Persistence
{
   public static class ModelBuilderExtensions
   {
      public static void Seed(this ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Company>().HasData(
            new Company
            {
               Id = 1,
               Name = "Test Company"
            });

         modelBuilder.Entity<Product>().HasData(
            new Product
            {
               Id = 1,
               Name = "Seed Product",
               CompanyId = 1,
               Description = "Seed Product",
               Price = 10,
               AgeRestriction = 10
            });
      }
   }
}
