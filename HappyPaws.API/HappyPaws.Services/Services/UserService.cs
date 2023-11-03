using HappyPaws.Application.Interfaces;
using HappyPaws.Core.Entities;
using HappyPaws.Core.Exceptions.Common;
using HappyPaws.Core.Interfaces;

namespace HappyPaws.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenManager _tokenManager;

        public UserService(IUserRepository userRepository, ITokenManager tokenManager)
        {
            _userRepository = userRepository;
            _tokenManager = tokenManager;
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

        public Task<User> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync(Guid id, User user)
        {
            return await _userRepository.UpdateAsync(id, user);
        }
    }
}
