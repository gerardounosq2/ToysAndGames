using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Core;

namespace ToysAndGames.Api.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class BaseController : ControllerBase
   {
      private readonly IMediator mediator;

      protected IMediator Mediator => mediator ?? HttpContext.RequestServices.GetService<IMediator>();

      protected ActionResult HandleResult<T>(Result<T> res)
      {
         if (res == null)
            return NotFound();

         if (res.IsSuccess && res.Value != null)
            return Ok(res.Value);
         if (res.IsSuccess && res.Value == null)
            return NotFound();
         return BadRequest(res.Error);
      }
   }
}
