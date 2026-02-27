using FluentValidation;
using MissTortas.Presentation.DTO.Products;

namespace MissTortas.Presentation.Validators.Products
{
    public class CreateProductCategoryDTOValidator: AbstractValidator<CreateProductCategoryDTO>
    {
        public long MaxParentId = long.MaxValue - 1024;
        public int NameMinLength = 3;
        public int NameMaxLength = 256;
        //public int DescriptionMaxLength = 256;
        public CreateProductCategoryDTOValidator()
        {
            RuleFor(createProduct => createProduct.Name).NotEmpty().Length(NameMinLength, NameMaxLength);
            RuleFor(createProduct => createProduct.ParentId).InclusiveBetween(0, MaxParentId);
        }
    }
}
