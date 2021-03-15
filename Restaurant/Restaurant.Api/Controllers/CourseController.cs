using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Services;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _ICourseService;


        public CourseController(ICourseService iCourseService)
        {
            _ICourseService = iCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _ICourseService.GetAllAsync());
        }
    }
}
