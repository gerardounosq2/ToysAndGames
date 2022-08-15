using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Persistence.Products
{
   public interface IProductRepository : IAsyncRepository<Product>
   {

   }
}