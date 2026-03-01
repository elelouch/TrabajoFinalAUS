using FluentValidation;
using MissTortas.Presentation.DTO.Products;

namespace MissTortas.Presentation.Validators.Products
{
    public class ProductsDTOValidator(
        IValidator<CreateProductCategory> productCategory,
        IValidator<CreateProduct> product,
        IValidator<CreateSaleProduct> saleProduct,
        IValidator<UpdateProduct> updateProduct
        ) : IProductsDTOValidator
    {
        public IValidator<CreateProductCategory> ProductCategoryValidator()
        {
            return productCategory;
        }

        public IValidator<CreateProduct> ProductValidator()
        {
            return product;
        }

        public IValidator<CreateSaleProduct> SaleProductValidator()
        {
            return saleProduct;
        }

        public IValidator<UpdateProduct> UpdateProductValidator()
        {
            return updateProduct;
        }
    }
}
