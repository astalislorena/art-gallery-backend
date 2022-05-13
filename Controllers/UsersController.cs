using ArtGallery.Models;
using ArtGallery.Providers.UserProvider;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserProvider _userProvider;

        public UsersController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var returnValue = _userProvider.QueryUsers().ToArray();
            return Ok(returnValue);
        }

        [HttpPost] 
        public IActionResult AddUser(string firstName, string lastName, string email, string password, UserType type)
        {
            var returnValue = _userProvider.AddUser(firstName, lastName, email, password, type);
            return Ok(returnValue);
        }

        [HttpGet]
        [Route("login")]
        public IActionResult CheckCreditentials(string email, string password)
        {
            var returnValue = _userProvider.CheckUserCreditentials(email, password);
            return Ok(returnValue);
        }
    }
}
