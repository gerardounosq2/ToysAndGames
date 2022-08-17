using FluentValidation;

namespace ToysAndGames.Core.Products
{
   public class CreateValidator : AbstractValidator<Create.Command>
   {
      public CreateValidator()
      {
         RuleFor(p => p.Product.AgeRestriction)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(100);
         RuleFor(p => p.Product.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(1000);
      }
   }
}