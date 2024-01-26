using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Architecture.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace activity_dashboard.Server.Controllers
{
    [ApiController]
    [Route("api/user/login")]
    public class UserLoginController : ControllerBase
    {
        private ILoginService _identityService;
        public UserLoginController(
          ILoginService identityService
           )
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        public ActionResult UserLogin([FromBody] TokenRequest model)
        {
            var response = _identityService.LoginAsync(model);
            if (response.isSuccessful)
            {
                return Ok(response);
            }
            return StatusCode(403, response);
        }        
    }
}
