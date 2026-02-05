using FluentValidation;
using MissTortas.Engine.DTO.Products;

namespace MissTortas.Engine.Validators.Products
{
    public class CreateSaleProductDTOValidator : AbstractValidator<CreateSaleProductDTO>
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
