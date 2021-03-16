using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _iCourseRepository;

        public CourseService(ICourseRepository iCourseRepository)
        {
            _iCourseRepository = iCourseRepository;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _iCourseRepository.GetAll();
        }
    }
}
