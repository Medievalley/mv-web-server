using AutoMapper;
using DataAccess.UserRepository;
using DataTransferObjects.UserDTOs;
using Entities;

namespace Domain.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> CreateUser(CreateUserDTO userDTO)
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(userDTO);
            int rowsAffected = await _userRepository.CreateUser(userEntity);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public async Task<GetUserDTO> GetUser(string userId)
        {
            UserEntity userEntity = await _userRepository.GetUserById(userId);
            if (!string.IsNullOrEmpty(userEntity.Login))
            {
                GetUserDTO userDTO = _mapper.Map<GetUserDTO>(userEntity);
                return userDTO;
            }
            return new GetUserDTO();
        }

        public async Task<bool> UpdateUser(UpdateUserDTO userDTO)
        {
            UserEntity userEntity = _mapper.Map<UserEntity>(userDTO);
            int rowsAffected = await _userRepository.UpdateUser(userEntity);
            if (rowsAffected == 1)
                return true;
            return false;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            int rowsAffected = await _userRepository.DeleteUser(userId);
            if (rowsAffected == 1)
                return true;
            return false;
        }
    }
}
