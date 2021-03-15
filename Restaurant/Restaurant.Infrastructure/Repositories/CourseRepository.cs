using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Infrastructure.Repositories
{
 
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private DataContext _appContext => (DataContext)_context;

        public CourseRepository(DataContext context) : base(context)
        {

        }
    }
}
