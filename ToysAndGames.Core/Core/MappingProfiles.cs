using AutoMapper;
using ToysAndGames.Domain.Dtos;
using ToysAndGames.Domain.Models;

namespace ToysAndGames.Core.Core
{
   public class MappingProfiles : Profile
   {
      public MappingProfiles()
      {
         CreateMap<Product, ProductDto>()
            .ForMember(dto => dto.CompanyName, opt => opt.MapFrom(p => p.Company.Name));
      }
   }
}