using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApiBackend.Models.DataModels;

namespace Service.cs
{
    public class Service
    {

        // GET: api/Courses/level
        [HttpGet("level")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByLevel(int lavel)
        {
            if (!(lavel >= 0) && !(lavel <= 3)) //si no esta detro de esterando ([0,3]) tiro un error
            {
                return NotFound();
            }


            var response = await _context.Courses.Where(course =>
                                                             course.Nivel.Equals(lavel) &&
                                                             course.students.Any())
                                                             .ToListAsync();

            return response;
        }

    }
}