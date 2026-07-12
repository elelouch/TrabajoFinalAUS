using MissTortas.Services.DTO.Products;
using MissTortas.View.DTO.Products;

namespace MissTortas.View.Mappers
{
    public interface IPresentationProductMapper
    {
        public SaleProductCreateDTO MapCreateSaleProductRequestToDTO(CreateSaleProductRequest req);
       
        public UpdateSaleProductDTO MapUpdateRequestToDto(long saleProductId, UpdateSaleProductRequest request);
        public List<SaleProductResponse> MapDtoToResponse(IEnumerable<SaleProductDTO> dtos);
        public SaleProductResponse MapDtoToResponse(SaleProductDTO dto, List<string> filePaths);
        public List<SaleProductResponse> MapDtoToResponse(IEnumerable<SaleProductDTO> dtos, Dictionary<long,List<string>> filePaths);
    }
}
