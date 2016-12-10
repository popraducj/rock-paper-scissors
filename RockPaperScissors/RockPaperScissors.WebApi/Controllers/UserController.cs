using RockPaperScissors.DatabaseEntities.Entities;
using RockPaperScissors.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RockPaperScissors.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public HttpResponseMessage Login(User user)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new {Succes = "yeye" });
        }
	}
}