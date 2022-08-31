using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        //TODO: Im not a fan of Repository, nevertheless if you are using this, please add Expressions as parameters 
        //so the caller can dynamically ask for information 
        //GetAll(x=>x.ProductId ==1) // GetAll(x=> x.ProductTypeId == SomeEnum), etc. 
        //public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,string includeProperties = "")
        //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application#create-a-generic-repository
        //

        
        public override async Task<ICollection<Product>> GetAllAsync()
      {
         return await context.Products.Include(r => r.Company).ToListAsync();
      }

        //TODO: If you do the one above you can remove this one
              public override async Task<Product> GetByIdAsync(int id)
      {
         return await context.Products.Include(r => r.Company).FirstOrDefaultAsync(r => r.Id == id);
      }
   }
}
