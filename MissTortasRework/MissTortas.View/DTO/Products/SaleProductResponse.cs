using MissTortas.Services.DTO.Products;

namespace MissTortas.View.DTO.Products
{
    public class SaleProductResponse : SaleProductDTO
    {
        public SaleProductResponse () { }
        public SaleProductResponse (SaleProductDTO dto)
        {
            this.Id = dto.Id;
            this.Price = dto.Price;
            this.Description = dto.Description;
            this.AllowDecimalAsk = dto.AllowDecimalAsk;
            this.Quantity = dto.Quantity;
            this.Name = dto.Name;
            this.StockProductId = dto.StockProductId;
        }
        public List<string> FilePaths { get; set; } = [];
    }
}
