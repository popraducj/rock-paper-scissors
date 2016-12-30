using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RockPaperScissors.Data.IRepositories;
using RockPaperScissors.DatabaseEntities.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Data.Repositories
{
    public class AuthRepository : IAuthRepository 
    {
        private IDatabaseContext _context;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _context = new DatabaseContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>((DatabaseContext)_context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();

        }
    }
}
