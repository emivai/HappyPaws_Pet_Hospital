using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Entities;
using HappyPaws.Core.Exceptions.Common;
using HappyPaws.Core.Interfaces;

namespace HappyPaws.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User> UpdateAsync(Guid id, User user)
        {
            return await _userRepository.UpdateAsync(id, user);
        }

        public async Task<SuccessfullLoginDTO> LoginAsync(LoginUserDTO userDTO)
        {
            var user = _userRepository.FirstOrDefault(x => x.Email == userDTO.Email);

            if (user == null) throw new BadRequestException("Email or password is invalid");

            if (!user.Verify(userDTO.Password)) throw new BadRequestException("Email or password is invalid");

            var accessToken = _tokenManager.CreateAccessTokenAsync(user);

            return new SuccessfullLoginDTO { AccessToken = accessToken };
        }
    }
}
