using FluentValidation;
using MissTortas.Engine.DTO.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Engine.Validators.Products
{
    public class CreateSaleProductDTOValidator : AbstractValidator<CreateSaleProductDTO>
    {
        public CreateSaleProductDTOValidator()
        {
            RuleFor(dto => dto.SaleQuantity).NotEmpty().InclusiveBetween(1, long.MaxValue - 1);
            RuleFor(dto => dto.SalePrice).NotEmpty().InclusiveBetween(0, double.MaxValue - 1);
            RuleFor(dto => dto.ProductId).NotEmpty().InclusiveBetween(0, long.MaxValue - 1);
            RuleFor(dto => dto.SaleDescription).MaximumLength(256);
        }
    }
}
