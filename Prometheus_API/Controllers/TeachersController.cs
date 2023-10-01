using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prometheus_API.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prometheus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly PROJECT_SPRINT1Context _context;

        public TeachersController(PROJECT_SPRINT1Context context)
        {
            _context = context;
            if (SessionController.sessionCodes == null)
            {
                SessionController session = new SessionController();
            }
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers([Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            return await _context.Teachers.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(decimal id,[Required] string code )
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] == "Student")
                return Unauthorized();

            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }


        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(decimal id, Teacher teacher,[Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] == "Student")
                return Unauthorized();
            teacher.TeacherId = id;
            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher,[Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTeacher", new { id = teacher.TeacherId }, teacher);
            return NoContent();
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(decimal id,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            var teacher = await _context.Teachers.FindAsync(id);
            var Teaches = _context.Teaches.Where(x => (x.TeacherId == id && x.Status == true)).ToList();
            var assignment = _context.Assignments.Where(x => (x.TeacherId == id && x.Status == true)).ToList();

            if (teacher == null)
            {
                return NotFound();
            }
            if (Teaches != null)
                foreach (var item in Teaches)
                {
                    item.Status = false;
                }
            if (assignment != null)
                foreach (var item in assignment)
                {
                    item.Status = false;
                }

            teacher.Status = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// Get HW given by this teacher
        /// </summary>
        /// <param name="id">teacher id</param>
        /// <returns>list of hw and its respective course</returns>
        [Route("Courses")]

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByTeacher(decimal id,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] == "Student")
                return Unauthorized();
            // return  await _context.Teaches.Where(x => (x.TeacherId == id && x.Status == true)).ToListAsync();
            return await _context.Teaches.Where(x => (x.TeacherId == id && x.Status == true)).Select(s => s.Course).ToListAsync();

        }

        [Route("Homework")]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHWByTeacher(decimal id,[Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
          
            else if (SessionController.sessionCodes[code] == "Student")
                return Unauthorized();
            //return await _context.Assignments.Where(x => (x.TeacherId == id && x.Status == true)).ToListAsync();
            return await _context.Assignments.Where(x => (x.TeacherId == id && x.Status == true)).Select(s => s.HomeWork).ToListAsync();

        }


        [Route("Assign")]

        [HttpPost]
        public async Task<ActionResult> AssignCourse(Teach teaches,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            _context.Teaches.Add(teaches);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTeacher", new { id = teacher.TeacherId }, teacher);
            return NoContent();
        }

        [HttpPost]
        [Route("DeAssign")]
        public async Task<ActionResult> DeAssign(Teach teaches, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            var teach = _context.Teaches.Where(x => (x.TeacherId == teaches.TeacherId && x.CourseId == teaches.CourseId)).FirstOrDefault();
            if (teach == null)
            {
                return NotFound();
            }
            teach.Status = false;
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
            return NoContent();
        }

        [Route("Login")]
        [HttpGet]
        public async Task<ActionResult<Teacher>> Login(decimal id, string password)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }
            if (teacher.Password == password)
            {
                var hash = Guid.NewGuid().ToString();
              
                if(teacher.IsAdmin)
                    SessionController.sessionCodes.Add(hash, "Admin");
                else
                    SessionController.sessionCodes.Add(hash, "Teacher");
                teacher.Address = hash;
                teacher.Password = "nonono";
                return teacher;
            }
            else

                return BadRequest();

        }




        private bool TeacherExists(decimal id)
        {
            return _context.Teachers.Any(e => e.TeacherId == id);
        }
    }
}
