using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Persistence.Products
{
    //TODO: Why this interface is empty? i could use the IAsyncRepository instead.
    public interface IProductRepository : IAsyncRepository<Product>
   {

        //Not implemented yet.. :) 
   }
}