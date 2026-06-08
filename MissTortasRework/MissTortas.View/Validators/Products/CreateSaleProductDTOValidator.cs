using FluentValidation;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Validators.Products
{
    public class CreateSaleProductDTOValidator : AbstractValidator<CreateSaleProductRequest>
    {
        public CreateSaleProductDTOValidator()
        {
            RuleFor(dto => dto.SaleQuantity).NotEmpty().ExclusiveBetween(0, decimal.MaxValue - 1);
            RuleFor(dto => dto.SaleProductName).NotEmpty().Length(3,256);
            RuleFor(dto => dto.SalePrice).NotEmpty().ExclusiveBetween(0, decimal.MaxValue - 1);
            RuleFor(dto => dto.SaleDescription).MaximumLength(256);
        }
    }
}
