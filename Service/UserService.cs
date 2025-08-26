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

        public async Task<bool> DeleteUserAsync(int UserId)
        {
            var existingUser = await _userRepo.GetByIdAsync(UserId);
            
            if (existingUser == null )
            {
                return false;
            }
            
            var deleteUser = await _userRepo.DeleteUserAsync(UserId);

            return deleteUser;

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
                return null; 
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

        public async Task<UserDTO> UpdateUserAsync(int UserId, UserPatchDTO userPatch )
        {
            var existingUser = await _userRepo.GetByIdAsync(UserId);

            if (existingUser == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(userPatch.FirstName))
                existingUser.FirstName = userPatch.FirstName;
            if (!string.IsNullOrEmpty(userPatch.LastName))
                existingUser.LastName = userPatch.LastName;
            if (!string.IsNullOrEmpty(userPatch.Email))
                existingUser.Email = userPatch.Email;
            if (!string.IsNullOrEmpty(userPatch.PasswordHash))
                existingUser.PasswordHash = userPatch.PasswordHash;
            if (!string.IsNullOrEmpty(userPatch.Role))
                existingUser.Role = userPatch.Role;
            
            var updateUserDB = await _userRepo.UpdateUserAsync(existingUser);
            
            var UserDTO = new UserDTO
            {
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email,
                PasswordHash = existingUser.PasswordHash,
                Role = existingUser.Role
            };
            
            return UserDTO;

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
