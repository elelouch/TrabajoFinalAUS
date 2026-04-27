using MissTortas.Domain.Security.Authorization;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Repositories;

namespace MissTortas.Services
{
    public class RightsService(IRightsRepository rightsRepository, IUserRepository userRepository) : IRightsService
    {
        public async Task<IEnumerable<T>> GetAvailableResourceForUser<T>(AccessType accessType, long userId) where T : Resource
        {
            var user = await userRepository.FindByIdAsync(userId);
            if (user is null)
            {
                return [];
            }
            var subjectsIds = user.Roles.Select(r => r.SubjectId).Append(user.SubjectId).ToArray();
            return await rightsRepository.GetAvailableResourceForSubjects<T>(accessType, subjectsIds);
        }

        public async Task GiveAccessAsync(RightDTO rightDTO)
        {
            var hasRight = await HasAccessAsync(rightDTO);
            if (hasRight)
            {
                return;
            }
            var right = ToEntity(rightDTO);
            await rightsRepository.InsertAsync(right);
            await rightsRepository.SaveChangesAsync();
        }

        public async Task<bool> HasAccessAsync(RightDTO rightDTO)
        {
            var (subjectId, resourceId, accessType, _) = DeconstructDTO(rightDTO);
            return await rightsRepository.ExistsAsync(subjectId, resourceId, accessType);
        }

        public async Task RevokeAccessAsync(RightDTO rightDTO)
        {
            var (subjectId, resourceId, accessType, _) = DeconstructDTO(rightDTO);
            await rightsRepository.DeleteAsync(subjectId, resourceId, accessType);
        }

        private static (long subjectId, long resourceId, AccessType at, bool transferable) DeconstructDTO(RightDTO rightDTO)
        {
            if (!Enum.IsDefined(typeof(AccessType), rightDTO.AccessType))
            {
                throw new InvalidOperationException($"Invalid AccessType value: {rightDTO.AccessType}");
            }

            return (rightDTO.SubjectId, rightDTO.ResourceId, (AccessType)rightDTO.AccessType, rightDTO.Transferable);
        }


        private static Right ToEntity(RightDTO rightDTO)
        {
            var (subjectId, resourceId, accessType, transferable) = DeconstructDTO(rightDTO);
            var right = new Right
            {
                AccessType = accessType,
                ResourceId = resourceId,
                SubjectId = subjectId,
                Transferable = transferable
            };
            return right;
        }
        private static IEnumerable<Right> ToEntity(IEnumerable<RightDTO> rightsDTO)
        {
            return rightsDTO.Select(r => ToEntity(r));
        }

        public async Task GiveAccessBulkAsync(IEnumerable<RightDTO> rightsDTO)
        {
            var rights = ToEntity(rightsDTO);
            await rightsRepository.BulkInsertAsync(rights);
            await rightsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAvailableResourceForSubject<T>(AccessType accessType, long subjectId) where T : Resource
        {
            return await rightsRepository.GetAvailableResourceForSubjects<T>(accessType, subjectId);
        }
    }
}
