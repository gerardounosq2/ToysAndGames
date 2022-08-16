using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Core.Products;
using ToysAndGames.Domain.Dtos;

namespace ToysAndGames.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ProductsController : BaseController
   {
      private readonly IMediator mediator;

      public ProductsController(IMediator mediator)
      {
         this.mediator = mediator;
      }

      [HttpGet(nameof(GetAll))]
      public async Task<IActionResult> GetAll()
      {
         return HandleResult(await mediator.Send(new GetAll.Command { }));
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         return HandleResult(await mediator.Send(new Get.Command { Id = id }));
      }

      [HttpPost(nameof(Create))]
      public async Task<IActionResult> Create(ProductInputDto product)
      {
         return HandleResult(await mediator.Send(new Create.Command { Product = product }));
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Update(ProductInputDto product, int id)
      {
         return HandleResult(await mediator.Send(new Update.Command { Id = id, ProductToUpdate = product }));
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         return HandleResult(await mediator.Send(new Delete.Command { Id = id }));
      }

   }
}
