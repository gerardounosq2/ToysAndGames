using Microsoft.EntityFrameworkCore;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Persistence.Products
{
   public class ProductRepository : BaseRepository<Product>, IProductRepository
   {
      private readonly ToysAndGamesDataContext context;

      public ProductRepository(ToysAndGamesDataContext context)
         : base(context)
      {
         this.context = context;
      }

      public override async Task<ICollection<Product>> GetAllAsync()
      {
         return await context.Products.Include(r => r.Company).ToListAsync();
      }

      public override async Task<Product> GetByIdAsync(int id)
      {
         return await context.Products.Include(r => r.Company).FirstOrDefaultAsync(r => r.Id == id);
      }
   }
}
