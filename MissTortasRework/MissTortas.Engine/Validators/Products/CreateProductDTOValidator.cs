using FluentValidation;
using MissTortas.Engine.DTO.Products;

namespace MissTortas.Engine.Validators.Products
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public long MaxProductId = long.MaxValue - 1024;
        public int NameMinLength = 3;
        public int NameMaxLength = 256;
        public int DescriptionMaxLength = 256;
        public CreateProductDTOValidator()
        {
            RuleFor(cp => cp.ManageQuantityAsInteger).NotEmpty();
            RuleFor(createProduct => createProduct.Name).NotEmpty().Length(NameMinLength, NameMaxLength);
            RuleFor(createProduct => createProduct.Description).MaximumLength(DescriptionMaxLength);
            RuleFor(createProduct => createProduct.CategoryId).NotEmpty().InclusiveBetween(1,MaxProductId);
        }
    }
}
