using FluentValidation;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Validators.Products
{
    public class CreateSaleProductDTOValidator : AbstractValidator<CreateSaleProduct>
    {
        public CreateSaleProductDTOValidator()
        {
            RuleFor(dto => dto.SaleQuantity).NotEmpty().ExclusiveBetween(0, double.MaxValue - 1).When(sp => sp.IsAvailable);
            RuleFor(dto => dto.SalePrice).NotEmpty().ExclusiveBetween(0, double.MaxValue - 1);
            RuleFor(dto => dto.StockProductId).NotEmpty().InclusiveBetween(0, long.MaxValue - 1);
            RuleFor(dto => dto.SaleDescription).MaximumLength(256);
        }
    }
}
