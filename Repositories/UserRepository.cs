using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;

namespace RestaurantAPI.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserasync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.UserId; 
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == id);

            return user;
        }

        public async Task<int> CreateUserAsync (User user)
        {   
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return user.UserId;

        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var RowAffected = await _context.Users.Where(u => u.UserId == id).ExecuteDeleteAsync();

            if (RowAffected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            var Result = await _context.SaveChangesAsync();

            if (Result != 0)
            {
                return true; 
            }

            return false; 
        }
    }
}
