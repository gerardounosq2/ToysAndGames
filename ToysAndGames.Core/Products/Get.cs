using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Products;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Get
   {
      public class Command : IRequest<Result<ProductDto>>
      {
         public int Id { get; set; }
      }
        //Factory.cs ... 
      public class GetCommandHandler : IRequestHandler<Command, Result<ProductDto>>
      {
         readonly IProductRepository repository;
         readonly IMapper mapper;

         public GetCommandHandler(IProductRepository repository, IMapper mapper)
         {
            this.repository = repository;
            this.mapper = mapper;
         }

         public async Task<Result<ProductDto>> Handle(Command request, CancellationToken cancellationToken)
         {
            return Result<ProductDto>.Success(mapper.Map<ProductDto>(await repository.GetByIdAsync(request.Id)));
         }
      }
   }
}