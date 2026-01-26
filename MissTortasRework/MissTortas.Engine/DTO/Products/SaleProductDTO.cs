using MissTortas.Data.Entity.Products;
using MissTortas.Services.DTO.Products;

namespace MissTortas.Engine.DTO.Products
{
    public class SaleProductDTO
    {
        public long Id { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;

        public static SaleProductDTO FromEntity(SaleProduct product)
        {
            return new SaleProductDTO
            {
                Id = product.Id,
                Price = product.SalePrice,
                Description = product.SaleDescription,
                Quantity = product.SaleQuantity
            };
        }

        public static List<SaleProductDTO> FromEntity(List<SaleProduct> products)
        {
            var list = new List<SaleProductDTO>(products.Count);
            foreach (var product in products)
            {
                list.Add(FromEntity(product));
            }
            return list;
        }
    }
}
