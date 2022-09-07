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

    public class CourseCategoriesController : ControllerBase
    {
        private readonly ELearningDBContext _context;

        public CourseCategoriesController(ELearningDBContext context)
        {
            _context = context;
        }

        // GET: api/CourseCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseCategory>>> GetCourseCategories()
        {
            return await _context.CourseCategories.ToListAsync();
        }

        


        // GET: api/CourseCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseCategory>> GetCourseCategory(int id)
        {
            var CourseCategory = await _context.CourseCategories.FirstAsync(c => c.Id == id);

            if (CourseCategory == null)
            {
                return NotFound();
            }

            return CourseCategory;
        }


        // GET: api/CourseCategories/{id}/Courses
        [HttpGet("{id}/Courses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesUnderCategory(int id)
        {
            
            return await _context.Courses.Where(c => c.CourseCategoryId == id).ToListAsync(); ;
        }



        // PUT: api/CourseCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseCategory(int id, CourseCategory CourseCategory)
        {
            if (id != CourseCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(CourseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseCategoryExists(id))
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

        // POST: api/CourseCategories
        [HttpPost]
        public async Task<ActionResult<CourseCategory>> CreateCourseCategory(CourseCategory CourseCategory)
        {
            _context.CourseCategories.Add(CourseCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseCategory", new { id = CourseCategory.Id }, CourseCategory);
        }

        // DELETE: api/CourseCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var CourseCategory = await _context.CourseCategories.FindAsync(id);
            if (CourseCategory == null)
            {
                return NotFound();
            }

            _context.CourseCategories.Remove(CourseCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseCategoryExists(int id)
        {
            return _context.CourseCategories.Any(e => e.Id == id);
        }

        

    }
}
