using MissTortas.Services.DTO.Security;

namespace MissTortas.Services.Interfaces
{
    public interface IUserService
    {
        public Task<long> CreateUserAsync(CreateUserDTO createUserDTO);
        public Task UpdateUserAsync(UpdateUserDTO updateUserDTO);
    }
}
