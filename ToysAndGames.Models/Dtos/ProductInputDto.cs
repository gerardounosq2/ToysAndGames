namespace ToysAndGames.Domain.Dtos
{
   public class ProductInputDto
   {
      public string Name { get; set; }

      public string Description { get; set; }

      public int AgeRestriction { get; set; }

      public int CompanyId { get; set; }

      public decimal Price { get; set; }
   }
}