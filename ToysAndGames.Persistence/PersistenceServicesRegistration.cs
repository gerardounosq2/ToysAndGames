using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToysAndGames.Persistence.Products;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Persistence
{
   public static class PersistenceServiceRegistration
   {
      public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddDbContext<ToysAndGamesDataContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("ToysAndGamesConnection")));
         services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
         services.AddScoped<IProductRepository, ProductRepository>();
         return services;
      }
   }
}