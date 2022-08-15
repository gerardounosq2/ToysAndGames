using MediatR;
using ToysAndGames.Core.Products;

namespace ToysAndGames.Api.Shared
{
   public static class AppServiceRegistration
   {
      public static IServiceCollection AddApplicationServices(this IServiceCollection services)
      {
         services.AddMediatR(typeof(GetAll.GetAllCommandHandler).Assembly);
         return services;
      }
   }
}