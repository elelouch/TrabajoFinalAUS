using FluentValidation;
using MissTortas.Engine.DTO.Products;

namespace MissTortas.Engine.Validators.Products
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(createProduct => createProduct.Name).NotEmpty().Length(3, 256);
            RuleFor(createProduct => createProduct.Description).MaximumLength(256);
        }
    }
}
