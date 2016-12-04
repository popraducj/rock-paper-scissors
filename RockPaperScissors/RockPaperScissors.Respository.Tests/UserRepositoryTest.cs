using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.Entities;
using RockPaperScissors.Respository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Respository.Tests
{
    [TestClass]
    class UserRepositoryTest
    {
        private UserRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new UserRepository();
        }

        [TestMethod]
        public void CreateUser()
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
