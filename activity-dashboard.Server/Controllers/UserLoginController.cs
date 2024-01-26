using activity_dashboard.Server.Architecture.Interfaces.IServices;
using activity_dashboard.Server.Architecture.Requests;
using Microsoft.AspNetCore.Mvc;

namespace activity_dashboard.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserLoginController : ControllerBase
    {
        private IUsersService _userService;
        public UserLoginController(
          IUsersService userService
           )
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult UserLogin([FromBody] TokenRequest model)
        {
            var response = _userService.LoginAsync(model);
            if (response.isSuccessful)
            {
                return Ok(response);
            }
            return StatusCode(403, response);
        }        
    }
}
