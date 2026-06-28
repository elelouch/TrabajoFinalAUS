using FluentValidation;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Validators.Products
{
    public class CreateSaleProductValidator : AbstractValidator<CreateSaleProductRequest>
    {
        public CreateSaleProductValidator()
        {
            RuleFor(dto => dto.SaleQuantity).InclusiveBetween(0, decimal.MaxValue - 1);
            RuleFor(dto => dto.SaleProductName).NotEmpty().Length(3, 256);
            RuleFor(dto => dto.SalePrice).NotEmpty().InclusiveBetween(0, decimal.MaxValue - 1);
            RuleFor(dto => dto.SaleDescription).MaximumLength(256);
        }
    }
}
