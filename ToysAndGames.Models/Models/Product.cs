﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysAndGames.Domain.Models
{
   public class Product
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public string Description { get; set; }

      public int AgeRestriction { get; set; }

      public Company Company { get; set; }

      public int CompanyId { get; set; }

      public decimal Price { get; set; }

      public int ReleaseYear { get; set; }
   }
}