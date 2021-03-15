using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
    }
   
}
