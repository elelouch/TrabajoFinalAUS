using FluentValidation;
using MissTortas.Presentation.DTO.Products;

namespace MissTortas.Presentation.Validators.Products
{
    public interface IProductsDTOValidator
    {
        public IValidator<CreateProductCategoryDTO> ProductCategoryValidator ();
        public IValidator<CreateProductDTO> ProductValidator();
        public IValidator<CreateSaleProductDTO> SaleProductValidator();
        public IValidator<UpdateProductDTO> UpdateProductValidator();
    }
}
