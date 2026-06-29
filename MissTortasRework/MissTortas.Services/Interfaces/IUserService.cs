using MissTortas.Services.DTO.Security;

namespace MissTortas.Services.Interfaces
{
    public interface IUserService
    {
        public Task<long> CreateUserAsync(CreateUserDTO createUserDTO);
        public Task<long> CreateRoleIfNotExistsAsync(string name);
        public Task UpdateUserAsync(UpdateUserDTO updateUserDTO);
        public Task UpdateRoleAsync(UpdateRoleDTO updateRoleDTO);
    }
}
