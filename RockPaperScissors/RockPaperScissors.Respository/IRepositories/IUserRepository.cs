using RockPaperScissors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Respository.IRepositories
{
    public interface IUserRepository
    {
         void createUser(User user);
    }
}
