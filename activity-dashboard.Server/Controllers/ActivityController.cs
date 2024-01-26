using activity_dashboard.Server.Architecture.Interfaces.IServices;
using activity_dashboard.Server.Architecture.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace activity_dashboard.Server.Controllers
{
    [ApiController]
    [Route("api/activity")]
    [Authorize]
    public class ActivityController : ControllerBase
    {
        IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public IActionResult GetAllActivities()
        {
            var response = _activityService.GetAllActivity();
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("start")]
        public IActionResult StartActivity(StartActivityRequest startActivityRequest)
        {
            var response = _activityService.StartActivity(startActivityRequest);
            if (response.isSuccessful)
            {
                return Ok(response);
            }
            return StatusCode(403, response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("end")]
        public IActionResult EndActivity(EndActivityRequest endActivityRequest)
        {
            var response = _activityService.EndActivity(endActivityRequest);
            if (response.isSuccessful)
            {
                return Ok(response);
            }
            return StatusCode(403, response);
        }

    }
}
