using FluentValidation;
using MediatR;
using ToysAndGames.Core.Core;
using ToysAndGames.Core.Products;

namespace ToysAndGames.Api.Shared
{
   public static class AppServiceRegistration
   {
      public static IServiceCollection AddApplicationServices(this IServiceCollection services)
      {
         services.AddMediatR(typeof(GetAll.GetAllCommandHandler).Assembly);
         services.AddAutoMapper(typeof(MappingProfiles).Assembly);
         services.AddValidatorsFromAssembly(typeof(Create.CreateCommandHandler).Assembly);
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
         return services;
      }
   }
}