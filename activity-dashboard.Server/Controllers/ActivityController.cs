using activity_dashboard.Server.Architecture.Interfaces.IServices;
using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace activity_dashboard.Server.Controllers
{
    [ApiController]
    [Route("api/activity")]
    [Authorize]
    public class ActivityController : ControllerBase
    {
        IActivityService _activityService;

        private readonly IHubContext<ActivityHub> _hubContext;
        public ActivityController(IActivityService activityService, 
            IHubContext<ActivityHub> hubContext)
        {
            _activityService = activityService;
            _hubContext = hubContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public IActionResult GetAllActivities()
        {
            var response = _activityService.GetStartedActivities();
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-user-started-activity")]
        public IActionResult GetUserStartedActivity()
        {
            var response = _activityService.GetUserStartedActivity();
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("start")]
        public async Task<IActionResult> StartActivity([FromBody] StartActivityRequest startActivityRequest)
        {
            var response = _activityService.StartActivity(startActivityRequest);
            if (response.isSuccessful)
            {
                await _hubContext.Clients.All.SendAsync("RefreshGrid");
                return Ok(response);
            }
            return StatusCode(403, response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("end")]
        public async Task<IActionResult> EndActivity([FromBody] EndActivityRequest endActivityRequest)
        {
            var response = _activityService.EndActivity(endActivityRequest);
            if (response.isSuccessful)
            {
                await _hubContext.Clients.All.SendAsync("RefreshGrid");
                return Ok(response);
            }
            return StatusCode(403, response);
        }        

    }
}
