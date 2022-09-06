using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LearningBackendAPI.Contexts;
using E_LearningBackendAPI.Entities;
using Microsoft.AspNetCore.Mvc;


namespace E_LearningBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CoursesController : ControllerBase
    {

        // GET: api/courses
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            List<Course> courses = DBSimulator.CoursesDb;

            return courses;
        }


        // GET: api/courses/2
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = DBSimulator.CoursesDb.Find(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/courses
        [HttpPost]
        public ActionResult<Course> CreateCourse([FromBody] Course course)
        {
            
            DBSimulator.CoursesDb.Add(course);

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }


        // PUT: api/courses/2
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            if (DBSimulator.CoursesDb.Exists(c => c.Id == id)) {
                int index = DBSimulator.CoursesDb.IndexOf(DBSimulator.CoursesDb.Find(c => c.Id == id));
                DBSimulator.CoursesDb.RemoveAt(index);
                DBSimulator.CoursesDb.Insert(index, course);
            }


            return NoContent();
        }

        


        //// GET: api/courses     take 1
        //[HttpGet]
        //public ActionResult<IEnumerable<Course>> GetCourses()
        //{
        //    List<Course> courses = new List<Course>();
        //    courses.Add( new Course()
        //        {
        //            Id = 1,
        //            Name = "Deplomacy 101",
        //            Description = "Diplomacy is the main instrument of foreign policy",
        //            Category = "Deplomacy",
        //            Author = "Mathew",
        //            Duration = new TimeSpan(30, 0, 0, 0)

        //        } );

        //    courses.Add( new Course()
        //        {
        //            Id = 1,
        //            Name = "International Relations 101",
        //            Description = " international studies is " +
        //            "the scientific study of interactions between sovereign states",
        //            Category = "International Relations",
        //            Author = "Jhon",
        //            Duration = new TimeSpan(60, 0, 0, 0)

        //        } );
        //    return courses;
        //}

    }
}
