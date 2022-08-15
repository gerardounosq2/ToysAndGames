using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Create
   {
      public class Command : IRequest
      {
         public ProductInputDto Product { get; set; }
      }

      public class CreateCommandHandler : IRequestHandler<Command>
      {
         readonly IAsyncRepository<Product> repository;
         readonly IMapper mapper;

         public CreateCommandHandler(IAsyncRepository<Product> repository, IMapper mapper)
         {
            this.repository = repository;
            this.mapper = mapper;
         }

         public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
         {
            var productMapped = mapper.Map<Product>(request.Product);
            await repository.AddAsync(productMapped);
            return Unit.Value;
         }
      }
   }
}
