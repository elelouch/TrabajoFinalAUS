using FluentValidation;
using MissTortas.Engine.DTO.Products;

namespace MissTortas.Engine.Validators.Products
{
    public interface IProductsDTOValidator
    {
        public IValidator<CreateProductCategoryDTO> ProductCategoryValidator ();
        public IValidator<CreateProductDTO> ProductValidator();
        public IValidator<CreateSaleProductDTO> SaleProductValidator();
        public IValidator<UpdateProductDTO> UpdateProductValidator();
    }
}
