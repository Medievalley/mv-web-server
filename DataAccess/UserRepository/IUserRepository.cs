using Entities;

namespace DataAccess.UserRepository
{
    public interface IUserRepository
    {
        Task<int> CreateUser(UserEntity userEntity);
        Task<int> UpdateUser(UserEntity userEntity);
        Task<int> DeleteUser(string userId);
        Task<UserEntity> GetUserById(string userId);
    }
}
