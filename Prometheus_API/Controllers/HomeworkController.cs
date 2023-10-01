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
    public class HomeworkController : ControllerBase
    {
        private readonly PROJECT_SPRINT1Context _context;

        public HomeworkController(PROJECT_SPRINT1Context context)
        {
            _context = context;
            if (SessionController.sessionCodes == null)
            {
                SessionController session = new SessionController();
            }
        }

        // GET: api/Homework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHomeworks([Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
           
            return await _context.Homeworks.ToListAsync();
        }

        // GET: api/Homework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homework>> GetHomework(decimal id, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            var homework = await _context.Homeworks.FindAsync(id);

            if (homework == null)
            {
                return NotFound();
            }

            return homework;
        }

        // PUT: api/Homework/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomework(decimal id, Homework homework,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] == "Student")
                return Unauthorized();
            homework.HomeWorkId =id;
            

            _context.Entry(homework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeworkExists(id))
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

        // POST: api/Homework
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostHomework(decimal courseId,decimal teacherId,Homework homework,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] == "Student")
                return Unauthorized();
            _context.Homeworks.Add(homework);
            await _context.SaveChangesAsync();
           var hwId =  _context.Homeworks.Max(x=>x.HomeWorkId);
            Assignment assignment = new Assignment() { CourseId = courseId, HomeWorkId = hwId, TeacherId = teacherId, Status = true };
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Homework/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomework(decimal id,[Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] == "Student")
                return Unauthorized();
            var homework = await _context.Homeworks.FindAsync(id);
            var assignment = _context.Assignments.Where(x => (x.HomeWorkId == id && x.Status == true)).ToList();
            if (homework == null)
            {
                return NotFound();
            }
            if (assignment != null)
                foreach (var item in assignment)
                {
                    item.Status = false;
                }

            homework.Status = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [Route("Course")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Assignment>>> GetCourseByHW(decimal id,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            return await _context.Assignments.Where(x => (x.HomeWorkId == id && x.Status == true)).ToListAsync();
        }

        [Route("Teacher")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Assignment>>> GetTeacherByHW(decimal id,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            return await _context.Assignments.Where(x => (x.HomeWorkId == id && x.Status == true)).ToListAsync();
        }
  
        private bool HomeworkExists(decimal id)
        {
            return _context.Homeworks.Any(e => e.HomeWorkId == id);
        }
    }
}
