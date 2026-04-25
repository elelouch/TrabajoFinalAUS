using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Security.Authorization;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Repositories
{
    public class RightsRepository(MissTortasContext context) : RepositoryCrud<Right>(context), IRightsRepository
    {
        private readonly DbSet<Right> rightsSet = context.Rights;
        public Task<bool> ExistsAsync(long subjectId, long resourceId, AccessType accessType)
        {
            return rightsSet.AnyAsync(r => r.SubjectId == subjectId && r.ResourceId == resourceId && r.AccessType == accessType);
        }
        public async Task DeleteAsync(long subjectId, long resourceId, AccessType accessType)
        {
            await rightsSet
                .Where(r => r.SubjectId == subjectId && r.ResourceId == resourceId && r.AccessType == accessType)
                .ExecuteDeleteAsync();
        }

        public async Task BulkInsertAsync(IEnumerable<Right> rights)
        {
            await rightsSet.AddRangeAsync(rights);
        }

        public async Task<IEnumerable<T>> GetAvailableResourceForSubjects<T>(
            AccessType accessType, params long[] subjectsId) where T : Resource
        {
            return await context.Set<T>()
                .Where(r => r.Rights.Any(rt => subjectsId.Contains(rt.SubjectId) && rt.AccessType == accessType))
                .ToListAsync();
        }
    }
}
