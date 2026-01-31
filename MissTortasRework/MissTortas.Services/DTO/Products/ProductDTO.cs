using MissTortas.Data.Entity.Products;
using System.Collections;

namespace MissTortas.Services.DTO.Products
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}