using MissTortas.Domain.Security.Authorization;
using MissTortas.Services.DTO.Security;

namespace MissTortas.Services.Interfaces
{
    public interface IRightsService
    {
        public Task<IEnumerable<T>> GetAvailableResourceForUser<T>(AccessType accessType, long userId) where T : Resource;
        public Task<bool> HasAccessAsync(RightDTO rightDTO);
        public Task GiveAccessAsync(RightDTO rightDTO);
        public Task GiveAccessBulkAsync(IEnumerable<RightDTO> rightDTO);
        public Task RevokeAccessAsync(RightDTO rightDTO);
    }
}
