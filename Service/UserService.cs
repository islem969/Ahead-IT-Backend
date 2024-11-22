using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Models;
using Register.Models.DTO;

namespace Register.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }



        public async Task<bool> UpdateUserAsync(int id, UserUpdateDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            user.LastName = userDto.LastName;
            user.FirstName = userDto.FirstName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Cin = userDto.Cin;
            user.Cnss = userDto.Cnss;
            user.Sex = userDto.Sex;
            user.birthdate = userDto.Birthdate;
            user.Hiringdate = userDto.Hiringdate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserProfileDto> GetUserProfileByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null; // Retourner null si l'utilisateur n'est pas trouvé
            }

            // Mapper les données de l'entité User vers UserProfileDto
            var userProfile = new UserProfileDto
            {
                RegistrationNumber = user.RegistrationNumber,
                Cnss = user.Cnss,
                Qualification = user.Qualification // Vous devrez mapper cela correctement selon vos besoins
            };

            return userProfile;
        }

        public async Task<ProfileDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new ProfileDto
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Username = user.Username,
                Password = user.Password
            };
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }   


}
