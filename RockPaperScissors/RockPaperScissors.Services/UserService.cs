using RockPaperScissors.Data.IRepositories;
using RockPaperScissors.DatabaseEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Services
{
    public class UserService : IUserService
    {
        #region initialization

        private IRepository<User> _userRepository;
        private IRepository<UserProfile> _userProfileRepository;
        public UserService(IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
            _userRepository = userRepository;
        }

        #endregion

        #region public methods

        public IQueryable<User> GetUsers()
        {
            return _userRepository.Table;
        }

        public User GetUser(long id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<bool> InsertUser(User user)
        {
            return await _userRepository.Insert(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<bool> DeleteUser(User user)
        {
            await _userProfileRepository.Delete(user.UserProfile);
            return await _userRepository.Delete(user);
        }
        #endregion
    }
}
