using MissTortas.Data.Entity.Products;
using System.Collections;

namespace MissTortas.Engine.DTO.Products
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public static ProductDTO FromEntity(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.ProductDetail.Description
            };
        }

        public static List<ProductDTO> FromEntity(List<Product> products)
        {
            var list = new List<ProductDTO>(products.Count);
            foreach (var product in products)
            {
                list.Add(FromEntity(product));
            }
            return list;
        }
    }
}