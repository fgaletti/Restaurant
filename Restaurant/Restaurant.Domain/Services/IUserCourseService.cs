using Restaurant.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services
{
    public interface IUserCourseService
    {
        Task<int> AddUserCourseAsync(UserCourseDto usercourseDto);

        IEnumerable<object> GetUserCourseList(int userid);
    }
}
