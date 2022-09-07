using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LearningBackendAPI.Contexts;
using E_LearningBackendAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_LearningBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CoursesController : ControllerBase
    {
        private readonly ELearningDBContext _context;

        public CoursesController(ELearningDBContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/courses/search?query={query}&category={category}&author={author}
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Course>>> SearchCourses(string query,string category, string author)
        {
            var searchQuery = _context.Courses.Include("CourseCategory").AsQueryable();

            if (query != null) {
                searchQuery = searchQuery.Where<Course>(c => c.Name.Contains(query) || c.Description.Contains(query));
                  
            }
            if (category != null)
            {
                searchQuery = searchQuery.Where<Course>(c => c.CourseCategory.Name.Contains(category));

            }

            if (author != null)
            {
                searchQuery = searchQuery.Where<Course>(c => c.Author.Contains(author));

            }

            return await searchQuery.ToListAsync();
        }


        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var Course = await _context.Courses.Include("Lessons").FirstAsync(c => c.Id == id);

            if (Course == null)
            {
                return NotFound();
            }

            return Course;
        }


        // GET: api/Courses/{id}/Lessons
        [HttpGet("{id}/Lessons")]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetLessonsForCourse(int id)
        {
            var Course = await _context.Courses.Include("Lessons").FirstAsync(c => c.Id == id);

            return Course.Lessons;
        }



        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course Course)
        {
            if (id != Course.Id)
            {
                return BadRequest();
            }

            _context.Entry(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course Course)
        {
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = Course.Id }, Course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var Course = await _context.Courses.FindAsync(id);
            if (Course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(Course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        

    }
}
