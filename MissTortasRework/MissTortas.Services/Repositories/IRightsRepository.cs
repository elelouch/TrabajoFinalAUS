using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Services.Repositories
{
    public interface IRightsRepository : IRepositoryCrud<Right>
    {
        public Task<IEnumerable<T>> GetAvailableResourceForSubjects<T>(AccessType accessType, params long[] subjectsId) where T : Resource;
        public Task<bool> ExistsAsync(long subjectId, long resourceId, AccessType accessType);
        public Task DeleteAsync(long subjectId, long resourceId, AccessType accessType);
        public Task BulkInsertAsync(IEnumerable<Right> rights);

    }
}
