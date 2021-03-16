using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Dtos
{
    public class UserCourseList
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CourseId { get; set; }
        public string CourseDescription { get; set; }
    }
}
