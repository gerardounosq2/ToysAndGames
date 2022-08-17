using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;
using Xunit.Abstractions;

namespace ToysAndGames.Tests.Integration
{
   public class ProductsControllerTests
   {
      private readonly ITestOutputHelper testOutput;
      private readonly WebApplicationFactory<Program> factory;

      public ProductsControllerTests(ITestOutputHelper testOutput)
      {
         factory = new WebApplicationFactory<Program>();
         this.testOutput = testOutput;
      }

      [Fact]
      public async void CanGetAllProducts()
      {
         //Arrange
         var client = factory.CreateDefaultClient();

         //Act
         var response = await client.GetAsync("/api/Products/GetAll");

         //Assert
         Assert.NotNull(response);
         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
         var responseContent = response.Content.ReadAsStringAsync().Result;
         Assert.NotEmpty(responseContent);
      }

      [Fact]
      public async void CannotCreateEmptyProduct()
      {
         //Arrange
         var client = factory.CreateDefaultClient();

         //Act
         var response = await client.PostAsync("/api/Products/Create", ContentHelper.GetStringContent(new Product()));

         //Assert
         Assert.NotNull(response);
         Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
      }

      [Fact]
      public async void CanGetSingleProduct()
      {
         var client = factory.CreateDefaultClient();

         var response = await client.GetAsync("/api/Products/2");
         Assert.NotNull(response);
         response.EnsureSuccessStatusCode();

         var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

         var singleProduct = JsonConvert.DeserializeObject<ProductDto>(jsonFromPostResponse);

         Assert.Equal("Gears of War 5", singleProduct.Description);
         Assert.Equal("Test Company", singleProduct.CompanyName);
         Assert.Equal(250, singleProduct.Price);
      }
   }
}