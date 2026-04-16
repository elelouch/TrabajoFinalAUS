using FluentValidation;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Validators.Products
{
    public class UpdateProductDTOValidator : AbstractValidator<UpdateProduct>
    {
        private readonly long CategoryIdMax = long.MaxValue - 1024;
        private readonly long CategoryIdMin = 0;
        private readonly int MaxLengthDescription = 256;
        private readonly double MaxQuantity = double.MaxValue - 1024;

        public UpdateProductDTOValidator()
        {
            RuleFor(up => up.CategoryId).InclusiveBetween(CategoryIdMin, CategoryIdMax);
            RuleFor(up => up.Description).MaximumLength(MaxLengthDescription);
            RuleFor(up => up.Quantity).InclusiveBetween(0, MaxQuantity);
        }
    }
}
