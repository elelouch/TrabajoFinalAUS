using FluentValidation;
using MissTortas.Presentation.DTO.Products;

namespace MissTortas.Presentation.Validators.Products
{
    public interface IProductsDTOValidator
    {
        public IValidator<CreateProductCategory> ProductCategoryValidator();
        public IValidator<CreateProduct> ProductValidator();
        public IValidator<CreateSaleProduct> SaleProductValidator();
        public IValidator<UpdateProduct> UpdateProductValidator();
    }
}
