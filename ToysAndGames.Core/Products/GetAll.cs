using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Persistence.Products;

namespace ToysAndGames.Core.Products
{
   public class GetAll
   {
      public class Command : IRequest<Result<ICollection<ProductDto>>>
      {

      }

      public class GetAllCommandHandler : IRequestHandler<Command, Result<ICollection<ProductDto>>>
      {
         readonly IProductRepository productRepo;
         readonly IMapper mapper;

         public GetAllCommandHandler(IProductRepository productRepo, IMapper mapper)
         {
            this.productRepo = productRepo;
            this.mapper = mapper;
         }

         public async Task<Result<ICollection<ProductDto>>> Handle(Command request, CancellationToken cancellationToken)
         {
            return Result<ICollection<ProductDto>>.Success(mapper.Map<ICollection<ProductDto>>(await productRepo.GetAllAsync()));

         }
      }
   }
}
