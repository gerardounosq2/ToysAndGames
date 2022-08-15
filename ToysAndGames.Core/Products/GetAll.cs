using MediatR;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class GetAll
   {
      public class Command : IRequest<ICollection<Product>>
      {

      }

      public class GetAllCommandHandler : IRequestHandler<Command, ICollection<Product>>
      {
         readonly IAsyncRepository<Product> productRepo;

         public GetAllCommandHandler(IAsyncRepository<Product> productRepo)
         {
            this.productRepo = productRepo;
         }

         public async Task<ICollection<Product>> Handle(Command request, CancellationToken cancellationToken)
         {
            return await productRepo.GetAllAsync();
         }
      }
   }
}
