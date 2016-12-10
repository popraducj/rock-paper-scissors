using RockPaperScissors.DatabaseEntities.Entities;
using RockPaperScissors.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RockPaperScissors.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(User user)
        {
            var returnedUser = _userService.GetUsers().Where(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password)).FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, returnedUser);
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Post(User user)
        {
            user.AddedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.IP = "test";
            user.UserProfile.IP = "test";
            user.UserProfile.AddedDate = DateTime.Now;
            user.UserProfile.ModifiedDate = DateTime.Now;
            _userService.InsertUser(user);

            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
	}
}