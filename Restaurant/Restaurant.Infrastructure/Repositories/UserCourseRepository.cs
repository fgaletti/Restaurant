using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Restaurant.Domain.Dtos;

namespace Restaurant.Infrastructure.Repositories
{
     public class UserCourseRepository : Repository<UserCourse>, IUserCourseRepository
    {
        private DataContext _appContext => (DataContext)_context;

        public UserCourseRepository(DataContext context) : base(context)
        {

        }

        public  IEnumerable<object> GetUserCourseList(int userid)
        {
            var userCourseList =  from userCourses in _appContext.UserCourses
                                       join courses in _appContext.Courses
                                       on userCourses.CourseId equals courses.Id
                                       join users in _appContext.Users
                                       on userCourses.UserId equals users.Id
                                       where userCourses.UserId == userid
                                       select new
                                       {
                                           UserId = userCourses.UserId,
                                           UserName = users.Name,
                                           CourseId = userCourses.CourseId,
                                           CourseDescription = courses.Description
                                       };

            return userCourseList;
        }
    }
}
