using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.Domain.Models;

namespace ToysAndGames.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(100);
            builder.Property(r => r.ReleaseYear).IsRequired();
            builder.HasData(Get());

        }
        public IList<Product> Get()
        {
            return new List<Product>() {
               new Product
               {
                   Id = 1,
                   Name = "Seed Product",
                   CompanyId = 1,
                   Description = "Seed Product",
                   Price = 10,
                   AgeRestriction = 10,
                   ReleaseYear = 2000
               }
            };
        }
    }
}
