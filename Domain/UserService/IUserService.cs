using DataTransferObjects.UserDTOs;

namespace Domain.UserService
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDTO userDTO);
        Task<bool> UpdateUser(UpdateUserDTO userDTO);
        Task<bool> DeleteUser(string userId);
        Task<GetUserDTO> GetUser(string userId);
    }
}
