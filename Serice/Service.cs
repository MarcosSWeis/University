using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Controllers;

namespace Serive
{
    public class Service

    {
        readonly UniversityContext _context;

        [HttpGet("level")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByLevel(int lavel)
        {
            if (!(lavel >= 0) && !(lavel <= 3)) //si no esta detro de esterando ([0,3]) tiro un error
                throw new NotImplementedException();


            var response = await _context.Courses.Where(course =>
                                                             course.Nivel.Equals(lavel) &&
                                                             course.students.Any())
                                                             .ToListAsync();
            return response;
        }


        // GET: api/Courses/emptycourses
        [HttpGet("emptycourses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetEmptyCourses()
        {
            var response = await _context.Courses.Where(course =>
                                                 !course.students.Any())
                                                 .ToListAsync();
            return response;
        }

        // GET: api/Courses/categoryAndLavel
        [HttpGet("categoryandlavel")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByCategoryAndLavel(int lavel, string categoria)
        {
            if (!(lavel >= 0) && !(lavel <= 3)) //si no esta detro de esterando ([0,3]) tiro un error
                throw new NotImplementedException();


            var cat = _context.Categories.Where(category => category.Name == categoria);

            if (cat == null)
                throw new NotImplementedException();


            var response = await _context.Courses.Where(course =>
                                                             course.Nivel.Equals(lavel) &&
                                                             course.Categories.Where(category => category == cat) != null).ToListAsync();

            return response;
        }


        // GET: api/Students/OlderStudents
        [HttpGet("olderstudents")]
        public async Task<ActionResult<IEnumerable<Student>>> OlderStudents()
        {
            var students = await _context.Students.Where(student => DateTime.Now.Year - student.Dob.Year >= 18).ToListAsync();

            if (students == null)
            {
                throw new NotImplementedException();

            }
            return students;
        }
        // GET: api/Students/WhitCourses
        [HttpGet("WhitCourses")]
        public async Task<ActionResult<IEnumerable<Student>>> GetSutudentWithCourse()
        {
            var students = await _context.Students.Where(student => student.Courses.Count > 0).ToListAsync();

            if (students == null)
            {
                throw new NotImplementedException();
            }
            return students;
        }

        // GET: api/Users/search?email=unEmail
        [HttpGet("search")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(user => user.Email == email).FirstOrDefaultAsync();

            if (user == null)
            {
               throw new NotImplementedException();
            }

            return user;
        }

    }
}