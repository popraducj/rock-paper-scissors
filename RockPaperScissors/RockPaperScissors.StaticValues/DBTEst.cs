using RockPaperScissors.Entities;
using RockPaperScissors.Respository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.BL
{
    public class DBTEst
    {
        private UserRepository _repository  = new UserRepository();

        public void test()
        {
            var user = new User
            {
                UserName = "Radu",
                Password = "Test"
            };
            _repository.createUser(user);
        }
    }
}
