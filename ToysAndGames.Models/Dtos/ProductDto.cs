namespace ToysAndGames.Domain.Dtos
{
   public class ProductDto
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      public int AgeRestriction { get; set; }

      public string CompanyName { get; set; }

      public decimal Price { get; set; }
   }
}
