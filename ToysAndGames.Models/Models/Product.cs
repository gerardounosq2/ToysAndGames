using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysAndGames.Domain.Models
{
   public class Product
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      [Range(0, 100, ErrorMessage = "Valid values are between 0 and 100")]
      public int AgeRestriction { get; set; }

      public Company Company { get; set; }

      public int CompanyId { get; set; }

      [Range(1,1000,ErrorMessage ="Valid values are between 1 and 1000")]
      public decimal Price { get; set; }

      public int ReleaseYear { get; set; }

      [NotMapped]
      public bool ElegibleForDiscount => ReleaseYear < 2015;
   }
}