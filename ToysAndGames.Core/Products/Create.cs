using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Create
   {
        //TODO: Why is the command class created on each Action and inside of each class ?
      public class Command : IRequest<Result<Unit>>
      {
            //TODO: if the command its always generic and the property wrapper is the one changing have you tought about a factory/builder
            //that can gives the command being asked for?
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
