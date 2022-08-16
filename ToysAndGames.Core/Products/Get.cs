using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;
using ToysAndGames.Persistence.Repository;

namespace ToysAndGames.Core.Products
{
   public class Get
   {
      public class Command : IRequest<Result<ProductDto>>
      {
         public int Id { get; set; }
      }

      public class GetCommandHandler : IRequestHandler<Command, Result<ProductDto>>
      {
         readonly IAsyncRepository<Product> repository;
         readonly IMapper mapper;

         public GetCommandHandler(IAsyncRepository<Product> repository, IMapper mapper)
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