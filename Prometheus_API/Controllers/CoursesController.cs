using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prometheus_API.Model;

namespace Prometheus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly PROJECT_SPRINT1Context _context;

        public CoursesController(PROJECT_SPRINT1Context context)
        {
            _context = context;
            if (SessionController.sessionCodes == null)
            {
                SessionController session = new SessionController();
            }
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses([Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(decimal id,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(decimal id, Course course,[Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(decimal id, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            var course = await _context.Courses.FindAsync(id);
            var enrollment = _context.Enrollments.Where(x => (x.CourseId == id && x.Status == true)).ToList();
            var assignmnets = _context.Assignments.Where(x => (x.CourseId == id && x.Status == true)).ToList();
            var teaches = _context.Teaches.Where(x => (x.CourseId == id && x.Status == true)).ToList();
            var homeworks = _context.Assignments.Where(x => (x.CourseId == id && x.Status == true)).Select(s=>s.HomeWork).ToList();
            if (course == null)
            {
                return NotFound();
            }
            if (enrollment != null)
                foreach (var item in enrollment)
                {
                    item.Status = false;
                }
            if (teaches != null)
                foreach (var item in teaches)
                {
                    item.Status = false;
                }
            if (assignmnets != null)
                foreach (var item in assignmnets)
                {
                    item.Status = false;
                }
            if (homeworks != null)
                foreach (var item in homeworks)
                {
                    item.Status = false;
                }
            course.Status = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [Route("Homework")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Homework>>> GetHWByCourse(decimal id, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            // return await _context.Assignments.Where(x => (x.CourseId == id && x.Status == true)).ToListAsync();
            return await _context.Assignments.Where(x => (x.CourseId == id && x.Status == true)).Select(s => s.HomeWork).ToListAsync();


        }

        [Route("Teacher")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacherByCourse(decimal id, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            // return await _context.Teaches.Where(x => (x.CourseId == id && x.Status == true)).ToListAsync();
            return await _context.Teaches.Where(x => (x.CourseId == id && x.Status == true)).Select(s => s.Teacher).ToListAsync();


        }

        [Route("Student")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Student>>> GetStudentByCourse(decimal id, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            //return await _context.Enrollments.Where(x => (x.CourseId == id && x.Status == true)).ToListAsync();
            return await _context.Enrollments.Where(x => (x.CourseId == id && x.Status == true)).Select(s => s.Student).ToListAsync();

        }


        private bool CourseExists(decimal id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
