using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Services;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _IUserCourseService;
        private readonly ILogger _logger;

        public UserCourseController( ILogger<CourseController> logger,
            IUserCourseService iUserCourseService)
        {
            _logger = logger;
            _IUserCourseService = iUserCourseService;
        }


        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            _logger.LogInformation("UserCourseController -> Get");
            return Ok( _IUserCourseService.GetUserCourseList(userId));
        }

    }
}
