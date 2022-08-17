using Microsoft.EntityFrameworkCore;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence;

namespace ToysAndGames.Test.Unit
{
   public class ProductTests : IDisposable
   {
      private static DbContextOptions<ToysAndGamesDataContext> options = new DbContextOptionsBuilder<ToysAndGamesDataContext>()
         .UseInMemoryDatabase(databaseName: "ProductDbTest")
         .Options;

      ToysAndGamesDataContext context;

      public ProductTests()
      {
         context = new ToysAndGamesDataContext(options);
         context.Database.EnsureCreated();
         Seed();
      }

      private async void Seed()
      {
         var company = new Company
         {
            Id = 1,
            Name = "Test Company"
         };

         var products = new List<Product>
         {
            new Product
            {
               Name = "Dying Light 2",
               AgeRestriction = 21,
               CompanyId = 1,
               Description = "Dying Light 2",
               Price = 1499,
               ReleaseYear = 2022
            },
            new Product
            {
               Name = "Nintendo Switch",
               AgeRestriction = 1,
               CompanyId = 1,
               Description = "Nintendo Switch OLED",
               Price = 7299,
               ReleaseYear = 2021
            },
            new Product
            {
               Name = "Red Dead Redemption 2",
               AgeRestriction = 21,
               CompanyId = 1,
               Description = "Red Dead Redemption 2",
               Price = 1099,
               ReleaseYear = 2019
            },
            new Product
            {
               Name = "Funko Pop: Minato Namikaze",
               AgeRestriction = 1,
               CompanyId = 1,
               Description = "Funko",
               Price = 499,
               ReleaseYear = 2012
            },
            new Product
            {
               Name = "Gears of War: Marcus statue",
               AgeRestriction = 10,
               CompanyId = 1,
               Description = "Gears of War: Marcus statue",
               Price = 1399,
               ReleaseYear = 2010
            }
         };

         await context.Companies.AddAsync(company);
         await context.Products.AddRangeAsync(products);
         await context.SaveChangesAsync();
      }

      public void Dispose() => context.Database.EnsureDeleted();

      [Fact]
      public void Test1()
      {
         Assert.True(context.Products.Any()); 
      }
   }
}