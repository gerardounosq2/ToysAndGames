using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Create
   {
      public class Command : IRequest<Result<Unit>>
      {
         public ProductInputDto Product { get; set; }
      }

      public class CreateCommandHandler : IRequestHandler<Command, Result<Unit>>
      {
         readonly IAsyncRepository<Product> repository;
         readonly IMapper mapper;

         public CreateCommandHandler(IAsyncRepository<Product> repository, IMapper mapper)
         {
            this.repository = repository;
            this.mapper = mapper;
         }

         public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
         {
            var productMapped = mapper.Map<Product>(request.Product);
            await repository.AddAsync(productMapped);
            return Result<Unit>.Success(Unit.Value);
         }
      }
   }
}
