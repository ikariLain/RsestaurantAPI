using ResturangAPI.DTOs.User;
using ResturangAPI.Models;
using ResturangAPI.Respositories.IRepositories;
using ResturangAPI.Service.IService;

namespace ResturangAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<int> CreateUser(UserCreateDTO UserDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateUserAsync(UserCreateDTO UserDTO)
        {
            var user = new User
            {
                Name = UserDTO.Name,
                Email = UserDTO.Email,
                PhoneNumber = UserDTO.PhoneNumber
            };

            var NewUserid = await _userRepo.CreateUserAsync(user);

            return NewUserid; 
        }

        public Task<bool> DeleteUserAsync(int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDTO>> GetAllUserAsync()
        {
            var users = await _userRepo.GetAllUserAsync();

            var usersDTO = users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email
            }).ToList();

            return usersDTO;
        }

        public async Task<UserDTO> GetByIdAsync(int UserId)
        {
            var user = await _userRepo.GetByIdAsync(UserId);

            if (user == null)
            {
                return null; // or throw an exception, depending on your error handling strategy
            }

            var userDTO = new UserDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return userDTO;
        }

        public Task<bool> UpdateUserAsync(int UserId)
        {
            throw new NotImplementedException();
        }

    }
}
