using RockPaperScissors.DatabaseEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Services
{
    public interface IUserService
    {
        User GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        IQueryable<User> GetUsers();
    }
}
