﻿using Microsoft.AspNet.Identity;
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
        Task<IdentityUser> FindAsync(UserLoginInfo loginInfo);
        Task<IdentityResult> CreateAsync(IdentityUser user);
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);

        Client FindClient(string clientId);
    }
}
