using RockPaperScissors.DAL;
using RockPaperScissors.Entities;
using RockPaperScissors.Respository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Respository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _context;
        public UserRepository()
            : this(DependencyFactory.Resolve<IDatabaseContext>())
        {
        
        }
        public UserRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public void createUser(User user)
        {
            _context.Users.Add(user);
        }
    }
}
