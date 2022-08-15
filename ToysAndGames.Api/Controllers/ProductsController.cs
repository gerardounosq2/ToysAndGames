﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToysAndGames.Core.Products;
using ToysAndGames.Domain.Dtos;

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

      [HttpPost(nameof(Create))]
      public async Task<IActionResult> Create(ProductInputDto product)
      {
         return Ok(await mediator.Send(new Create.Command { Product = product }));
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Update(ProductInputDto product, int id)
      {
         return Ok(await mediator.Send(new Update.Command { Id = id, ProductToUpdate = product }));
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         return Ok(await mediator.Send(new Delete.Command { Id = id }));
      }

   }
}