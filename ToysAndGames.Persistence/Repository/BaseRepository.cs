using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ToysAndGames.Persistence.Repository
{
   public class BaseRepository<T> : IAsyncRepository<T> where T : class
   {
      protected readonly ToysAndGamesDataContext context;

      public BaseRepository(ToysAndGamesDataContext context)
      {
         this.context = context;
      }

      public virtual async Task<T> AddAsync(T entity)
      {
         try
         {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
         }
         catch (Exception)
         {

         }
         return entity;
      }

      public async Task DeleteAsync(T entity)
      {
         context.Set<T>().Remove(entity);
         await context.SaveChangesAsync();
      }

      public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
      {
         return await context.Set<T>().SingleOrDefaultAsync(predicate);
      }

      public virtual async Task<ICollection<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

      public virtual async Task<T> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);

      public async Task UpdateAsync(T entity)
      {
         try
         {
            context.Update(entity);
            await context.SaveChangesAsync();
         }
         catch (Exception ex)
         {

            throw;
         }
      }
   }
}
