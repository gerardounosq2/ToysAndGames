using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Core.Products;

namespace ToysAndGames.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ProductsController : ControllerBase
   {
      private readonly IMediator mediator;

      public ProductsController(IMediator mediator)
      {
         this.mediator = mediator;
      }

      [HttpGet(nameof(GetAll))]
      public async Task<IActionResult> GetAll()
      {
         return Ok(await mediator.Send(new GetAll.Command { }));
      }
   }
}
