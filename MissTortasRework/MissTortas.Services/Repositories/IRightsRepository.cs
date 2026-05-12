using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Services.Repositories
{
    public interface IRightsRepository : IRepositoryCrud<Right>
    {
        public IAsyncEnumerable<Resource> GetAvailableResourceForSubjects(AccessType accessType, params long[] subjectsId);
        public Task<bool> ExistsAsync(long subjectId, long resourceId, AccessType accessType);
        public Task DeleteAsync(long subjectId, long resourceId, AccessType accessType);
        public Task BulkInsertAsync(IEnumerable<Right> rights);

    }
}
