using MediatR;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Delete
   {
      public class Command : IRequest<Result<Unit>>
      {
         public int Id { get; set; }
      }

      public class DeleteCommandHandler : IRequestHandler<Command, Result<Unit>>
      {
         readonly IAsyncRepository<Product> repository;

         public DeleteCommandHandler(IAsyncRepository<Product> repository)
         {
            this.repository = repository;
         }

         public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
         {
            await repository.DeleteAsync(new Product { Id = request.Id });
            return Result<Unit>.Success(Unit.Value);
         }
      }
   }
}
