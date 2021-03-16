using Restaurant.Domain.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IUserCourseRepository _iUserCourseRepository;

        public UserCourseService(IUserCourseRepository iUserCourseRepository)
        {
            _iUserCourseRepository = iUserCourseRepository;
        }
      

        public async Task<int> AddUserCourseAsync(UserCourseDto usercourseDto)
        {
            UserCourse userCourse = new UserCourse();
            userCourse.CourseId = usercourseDto.CourseId;
            userCourse.UserId = usercourseDto.UserId;

             _iUserCourseRepository.Add(userCourse);
           return await _iUserCourseRepository.UnitOfWork.SaveChangesAsync();
        }

        public IEnumerable<object> GetUserCourseList(int userid)
        {
            return _iUserCourseRepository.GetUserCourseList(userid);
        }
    }
}
