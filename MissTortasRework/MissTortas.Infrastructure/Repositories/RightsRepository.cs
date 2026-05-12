using Microsoft.EntityFrameworkCore;
using MissTortas.Domain.Security.Authorization;
using MissTortas.Infrastructure.Context;
using MissTortas.Services.Repositories;

namespace MissTortas.Infrastructure.Repositories
{
    public class RightsRepository(MissTortasContext context) : RepositoryCrud<Right>(context), IRightsRepository
    {
        private readonly DbSet<Right> rightsSet = context.Rights;
        private readonly DbSet<Resource> resourcesSet = context.Resources;

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

        public IAsyncEnumerable<Resource> GetAvailableResourceForSubjects(AccessType[] accessTypes, params long[] subjectsId)
        {
            return resourcesSet
                .Where(r => r.Rights.Any(rt => subjectsId.Contains(rt.SubjectId) && accessTypes.Contains(rt.AccessType)))
                .ToAsyncEnumerable();
        }

        public static IQueryable<T> WhereHasRight<T>(
            this IQueryable<T> query,
            IQueryable<Right> rights,
            IReadOnlyCollection<long> subjectsIds,
            IReadOnlyCollection<AccessType> accessTypes)
            where T : IHasResource
        {
            return query.Where(entity =>
                rights.Any(r =>
                    subjectsIds.Contains(r.SubjectId) &&
                    r.ResourceId == entity.ResourceId &&
                    accessTypes.Contains(r.AccessType)));
        }
    }
}
