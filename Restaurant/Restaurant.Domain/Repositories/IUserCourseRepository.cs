using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Repositories
{
    public interface IUserCourseRepository :  IRepository<UserCourse>
    {
        IEnumerable<object> GetUserCourseList(int userid);
    }
}
