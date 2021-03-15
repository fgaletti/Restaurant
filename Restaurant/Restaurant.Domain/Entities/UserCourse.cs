using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Entities
{
    public class UserCourse
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
    
}
