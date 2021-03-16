using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Dtos;
using Restaurant.Domain.Services;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _ICourseService;
        private readonly IUserCourseService _IUserCourseService;
        private readonly ILogger _logger;

        public CourseController(ICourseService iCourseService,  ILogger<CourseController> logger,
            IUserCourseService iUserCourseService)
        {
            _ICourseService = iCourseService;
            _logger = logger;
            _IUserCourseService = iUserCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("CourseController -> Get");
            return Ok(await _ICourseService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddUserCourse(UserCourseDto userCourseDto)
        {
            _logger.LogInformation("CourseController -> Get");
            return Ok(await _IUserCourseService.AddUserCourseAsync(userCourseDto));
        }
    }
}
