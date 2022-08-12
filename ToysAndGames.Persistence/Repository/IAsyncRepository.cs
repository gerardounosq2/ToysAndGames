using System.Linq.Expressions;

namespace ToysAndGames.Persistence.Repository
{
   public interface IAsyncRepository<T> where T : class
   {
      Task<T> GetByIdAsync(int id);
      Task<T> AddAsync(T entity);
      Task UpdateAsync(T entity);
      Task DeleteAsync(T entity);
      Task<T> FindAsync(Expression<Func<T, bool>> predicate);
      Task<ICollection<T>> GetAllAsync();
   }
}