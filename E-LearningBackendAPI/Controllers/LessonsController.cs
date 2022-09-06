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

    public class LessonsController : ControllerBase
    {
        private readonly ELearningDBContext _context;

        public LessonsController(ELearningDBContext context)
        {
            _context = context;
        }

      

        // GET: api/Lessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var Lesson = await _context.Lessons.FindAsync(id);

            if (Lesson == null)
            {
                return NotFound();
            }

            return Lesson;
        }

        // PUT: api/Lessons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, Lesson Lesson)
        {
            if (id != Lesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(Lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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

        // POST: api/Lessons
        [HttpPost]
        public async Task<ActionResult<Lesson>> CreateLesson(Lesson Lesson)
        {
            _context.Lessons.Add(Lesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLesson", new { id = Lesson.Id }, Lesson);
        }

        // DELETE: api/Lessons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var Lesson = await _context.Lessons.FindAsync(id);
            if (Lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(Lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }

        

    }
}
