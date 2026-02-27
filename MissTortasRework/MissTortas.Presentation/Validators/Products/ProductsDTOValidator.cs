using FluentValidation;
using MissTortas.Presentation.DTO.Products;

namespace MissTortas.Presentation.Validators.Products
{
    public class ProductsDTOValidator(
        IValidator<CreateProductCategoryDTO> productCategory,
        IValidator<CreateProductDTO> product,
        IValidator<CreateSaleProductDTO> saleProduct,
        IValidator<UpdateProductDTO> updateProduct
        ) : IProductsDTOValidator
    {
        public IValidator<CreateProductCategoryDTO> ProductCategoryValidator()
        {
            return productCategory;
        }

        public IValidator<CreateProductDTO> ProductValidator()
        {
            return product;
        }

        public IValidator<CreateSaleProductDTO> SaleProductValidator()
        {
            return saleProduct;
        }

        public IValidator<UpdateProductDTO> UpdateProductValidator()
        {
            return updateProduct;
        }
    }
}
