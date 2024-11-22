using Register.Models;
using Register.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Register.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task UpdateUser(int id, User user);
        Task DeleteUser(int id);
        Task<bool> UpdateUserAsync(int id, UserUpdateDto userDto);
        Task<UserProfileDto> GetUserProfileByIdAsync(int id);

        //profile///////////////////////////////
        Task<ProfileDto> GetUserByIdAsync(int id);
        //ajout avec affectation /////////////

        Task<User> AddUserAsync(User user);

    }
}
