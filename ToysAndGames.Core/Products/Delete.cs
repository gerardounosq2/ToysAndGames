using MediatR;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Delete
   {
      public class Command : IRequest
      {
         public int Id { get; set; }
      }

      public class DeleteCommandHandler : IRequestHandler<Command>
      {
         readonly IAsyncRepository<Product> repository;

         public DeleteCommandHandler(IAsyncRepository<Product> repository)
         {
            this.repository = repository;
         }

         public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
         {
            await repository.DeleteAsync(new Product { Id = request.Id });
            return Unit.Value;
         }
      }
   }
}
