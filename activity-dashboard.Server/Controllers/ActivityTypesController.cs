using activity_dashboard.Server.Architecture.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace activity_dashboard.Server.Controllers
{
    [ApiController]
    [Route("api/activity-type")]
    [Authorize]

    public class ActivityTypesController : ControllerBase
    {
        private IActivityTypeService _activityTypeService;
        public ActivityTypesController(
          IActivityTypeService  activityTypeService
           )
        {
            _activityTypeService = activityTypeService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public IActionResult GetAllActivityTypes()
        {
            return Ok(_activityTypeService.GetAllActiveActivityTypes());
        }
    }
}
