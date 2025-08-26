using RestaurantAPI.DTOs.User;
using RestaurantAPI.Models;
using RestaurantAPI.Respositories.IRepositories;
using RestaurantAPI.Service.IService;

namespace RestaurantAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        //TODO: Implement CreateUserAsync method

        public Task<int> CreateUser(UserCreateDTO UserDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateUserAsync(UserCreateDTO UserDTO)
        {
            var user = new User
            {
                FirstName = UserDTO.FirstName,
                LastName = UserDTO.LastName,
                Email = UserDTO.Email,
                PasswordHash = UserDTO.PasswordHash,
                Role = UserDTO.Role

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
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                Role = u.Role

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
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = user.Role

            };

            return userDTO;
        }

        //TODO: Implement UpdateUserAsync method 

        public Task<bool> UpdateUserAsync(int UserId)
        {
            throw new NotImplementedException();
        }

        //TODO: Implement DeleteUserAsync method

        Task<List<CustomerDTO>> IUserService.GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        //TODO: Implement GetByIdAsync method
        Task<CustomerDTO> IUserService.GetByIdAsync(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
