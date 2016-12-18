using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RockPaperScissors.DatabaseEntities.Entities;
using System;
using System.Threading.Tasks;

namespace RockPaperScissors.Data.IRepositories
{
    public interface IAuthRepository : IDisposable
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
