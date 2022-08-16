using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Update
   {
      public class Command : IRequest<Result<Unit>>
      {
         public int Id { get; set; }
         public ProductInputDto ProductToUpdate { get; set; }
      }

      public class UpdateCommandHandler : IRequestHandler<Command, Result<Unit>>
      {
         private readonly IMapper mapper;
         private readonly IAsyncRepository<Product> repository;

         public UpdateCommandHandler(IAsyncRepository<Product> repository, IMapper mapper)
         {
            this.repository = repository;
            this.mapper = mapper;
         }

         public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
         {
            var product = mapper.Map<Product>(request.ProductToUpdate);
            product.Id = request.Id;
            await repository.UpdateAsync(product);
            return Result<Unit>.Success(Unit.Value);
         }
      }
   }
}