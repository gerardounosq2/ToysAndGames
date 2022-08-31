using Microsoft.EntityFrameworkCore;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence;

namespace ToysAndGames.Test.Unit
{
    //TODO: Technically there are no Unit test here, just integration tests.
   public class ProductTests : IDisposable
   {
      private static DbContextOptions<ToysAndGamesDataContext> inMemoryOptions = new DbContextOptionsBuilder<ToysAndGamesDataContext>()
         .UseInMemoryDatabase(databaseName: "ProductDbTest")
         .Options;

      readonly ToysAndGamesDataContext context;

      public ProductTests()
      {
         context = new ToysAndGamesDataContext(inMemoryOptions);
         context.Database.EnsureCreated();
         Seed();
      }

      private async void Seed()
      {
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

         await context.Products.AddRangeAsync(products);
         await context.SaveChangesAsync();
      }

      public void Dispose() => context.Database.EnsureDeleted();

      [Fact]
      public async void CanCreateProduct()
      {
         var newProduct = new Product
         {
            Name = "Dying Light",
            AgeRestriction = 21,
            CompanyId = 1,
            Description = "Dying Light",
            Price = 1399,
            ReleaseYear = 2019
         };

         await context.Products.AddAsync(newProduct);
         await context.SaveChangesAsync();

         Assert.True(context.Products.Count() == 7);
         Assert.True(context.Products.Any(r => r.Id == 7));
      }

      [Fact]
      public async void CanDeleteProduct()
      {
         var productToDelete = new Product { Id = 1 };

         context.Products.Remove(productToDelete);

         await context.SaveChangesAsync();

         Assert.True(context.Products.Count() == 5);
         Assert.False(context.Products.Any(r => r.Id == 1));

      }

      [Fact]
      public async void CanUpdateProduct()
      {
         var productToUpdate = await context.Products.FindAsync(2);
         productToUpdate.Description = "This is an update test";

         await context.SaveChangesAsync();

         var updatedProduct = await context.Products.FindAsync(2);

         Assert.Equal("This is an update test", updatedProduct.Description);
      }

      [Fact]
      public async void AnyProductsWithDiscount()
      {
         var discounted = await context.Products
            .Where(r => r.ReleaseYear < 2015)
            .ToListAsync();
         Assert.True(discounted.Any());
         Assert.True(discounted.Count == 3);

      }

      [Fact]
      public async void CannotSaveIfRequiredPropertyIsEmpty()
      {
         var incorrectProduct = new Product
         {
            Description = "This should throw an exception",
            CompanyId = 1,
            Price = 10,
            ReleaseYear = 2000,
         };
         await context.Products.AddAsync(incorrectProduct);


         Assert.Throws<DbUpdateException>(() => context.SaveChanges());
      }
   }
}