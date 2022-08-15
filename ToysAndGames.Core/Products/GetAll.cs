using AutoMapper;
using MediatR;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Persistence.Products;

namespace ToysAndGames.Core.Products
{
   public class GetAll
   {
      public class Command : IRequest<ICollection<ProductDto>>
      {

      }

      public class GetAllCommandHandler : IRequestHandler<Command, ICollection<ProductDto>>
      {
         readonly IProductRepository productRepo;
         readonly IMapper mapper;

         public GetAllCommandHandler(IProductRepository productRepo, IMapper mapper)
         {
            this.productRepo = productRepo;
            this.mapper = mapper;
         }

         public async Task<ICollection<ProductDto>> Handle(Command request, CancellationToken cancellationToken)
         {
            return mapper.Map<ICollection<ProductDto>>(await productRepo.GetAllAsync());
         }
      }
   }
}
