using FluentValidation;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Validators.Products
{
    public class CreateSaleProductDTOValidator : AbstractValidator<CreateSaleProduct>
    {
        public CreateSaleProductDTOValidator()
        {
            RuleFor(dto => dto.SalePrice).NotEmpty().ExclusiveBetween(0, double.MaxValue - 1);
            RuleFor(dto => dto.SaleDescription).MaximumLength(256);
        }
    }
}
