using MissTortas.Domain.Security.Users;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Repositories;

namespace MissTortas.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<long> CreateRoleAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException($"Name is not valid: {name}");
            }
            var role = await userRepository.CreateRoleAsync(name);
            return role.RoleId;
        }

        public async Task<long> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var normalizedRoles = createUserDTO.Roles.Select(roleName => roleName.ToUpper()).ToList();
            var user = new User
            {
                Birthday = createUserDTO.BirthDay,
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName,
                Roles = await userRepository.GetRolesByNameAsync(normalizedRoles)
            };
            await userRepository.InsertAsync(user);
            await userRepository.SaveChangesAsync();
            return user.UserId;
        }

        public async Task UpdateRoleAsync(UpdateRoleDTO updateRoleDTO)
        {
            var role = await userRepository.FindRoleByIdAsync(updateRoleDTO.Id) ?? throw new RoleNotFound("Role not found");
            if(!string.IsNullOrEmpty(updateRoleDTO.Name))
            {
                role.Name = updateRoleDTO.Name;
            }
            await userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UpdateUserDTO updateUserDTO)
        {
            ArgumentNullException.ThrowIfNull(updateUserDTO);
            if (string.IsNullOrEmpty(updateUserDTO.FirstName) || updateUserDTO.FirstName.Length < 3)
            {
                throw new InvalidDataException("FirstName must have at least three characters.");
            }
            if (string.IsNullOrEmpty(updateUserDTO.LastName) || updateUserDTO.LastName.Length < 3)
            {
                throw new InvalidDataException("LastName must have at least three characters.");
            }
            var user = await userRepository.FindByIdAsync(updateUserDTO.UserId) ?? throw new InvalidDataException($"UserId must be a valid. UserId: {updateUserDTO.UserId}");
            user.FirstName = updateUserDTO.FirstName;
            user.LastName = updateUserDTO.LastName;
            var rolesFetched = await userRepository.GetRolesByNameAsync([.. updateUserDTO.Roles.Select(r => r.ToUpper())]);
            var rolesNotFound = rolesFetched.Select(r => r.Name).Except(updateUserDTO.Roles).ToList();
            if (rolesNotFound.Count > 0)
            {
                throw new InvalidOperationException($"The following roles couldnt be fetched: {string.Join(",", rolesNotFound)}");
            }
            user.Roles = rolesFetched;

            await userRepository.SaveChangesAsync();
        }
    }
}
