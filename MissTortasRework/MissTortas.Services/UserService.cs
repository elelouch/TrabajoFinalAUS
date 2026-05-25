using MissTortas.Domain.Security.Users;
using MissTortas.Services.DTO.Security;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Repositories;

namespace MissTortas.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<long> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = new User
            {
                Birthday = createUserDTO.BirthDay,
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName
            };
            await userRepository.InsertAsync(user);
            await userRepository.SaveChangesAsync();
            return user.UserId;
        }
    }
}
