using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prometheus_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Prometheus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly PROJECT_SPRINT1Context _context;
        

        public StudentsController(PROJECT_SPRINT1Context context)
        {
            _context = context;
            if (SessionController.sessionCodes == null)
            {
                SessionController session = new SessionController();
            }

        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents([Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(decimal id,[Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();

                var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(decimal id, Student student, [Required]string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] == "Teacher")
                return Unauthorized();
            student.StudentId = id;
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student,[Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if (SessionController.sessionCodes[code] != "Admin")
                return Unauthorized();
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
            return NoContent();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(decimal id, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            else if(SessionController.sessionCodes[code]!="Admin")
                return Unauthorized();
            var student = await _context.Students.FindAsync(id);
            var enrollment = _context.Enrollments.Where(x => (x.StudentId == id && x.Status == true)).ToList();
            if (student == null)
            {
                return NotFound();
            }
            if (enrollment != null)
                foreach (var item in enrollment)
                {
                    item.Status = false;
                }


            student.Status = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("Courses")]
        // Get: api/Students/Courses
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByStudent(decimal id, [Required] string code)
        {
            //if (HttpContext.Session.GetString("Id") == null)
            //    return Redirect("https://localhost:44344/StudentHome");
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            return await _context.Enrollments.Where(x => (x.StudentId == id && x.Status == true)).Select(s=>s.Course).ToListAsync();
            
        }
        [Route("Homework")]
        [HttpGet]

        public List<Homework> GetHomeworkForStudent(decimal id,[Required]string code)
        {
            List<Homework> homeworks = new List<Homework>();
            if (!SessionController.sessionCodes.ContainsKey(code))
                return homeworks;
            var enrollment =  _context.Enrollments.Where(x => (x.StudentId == id && x.Status == true)).ToList();
            
            foreach(var item in enrollment)
            {
                var homework = (from s in _context.Assignments
                                    where s.CourseId == item.CourseId && s.Status==true
                                    select s.HomeWork).ToList();
                foreach(var element in homework)
                {
                    homeworks.Add(element);
                }
            }
            return homeworks;

        }

        [HttpPost]
        [Route("Enroll")]
        public async Task<ActionResult<Student>> PostEnrollment(Enrollment enrollment, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
            return NoContent();
        }
        [HttpPost]
        [Route("DeEnroll")]
        public async Task<ActionResult> DeEnrollment(Enrollment enrollment, [Required] string code)
        {
            if (!SessionController.sessionCodes.ContainsKey(code))
                return Unauthorized();
            var enrollments = _context.Enrollments.Where(x => (x.StudentId == enrollment.StudentId && x.CourseId == enrollment.CourseId)).FirstOrDefault();
            if (enrollments == null)
            {
                return NotFound();
            }
            enrollments.Status = false;
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
            return NoContent();
        }

        private bool StudentExists(decimal id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

        [Route("Login")]
        [HttpGet]
        public async Task<ActionResult<Student>> Login(decimal id, string password)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            if (student.Password == password)
            {
                var hash = Guid.NewGuid().ToString();
                
                SessionController.sessionCodes.Add(hash,"Student");
                student.Address = hash;
                student.Password = "nonono";
                return student;
            }
            else

                return BadRequest();
            
        }
        



    }
}
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsController : ControllerBase
//    {
//        private readonly PROJECT_SPRINT1Context _context;

//        public StudentsController(PROJECT_SPRINT1Context context)
//        {
//            _context = context;
//        }

//        // GET: api/Students
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
//        {
//            return await _context.Students.ToListAsync();
//        }

//        // GET: api/Students/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Student>> GetStudent(decimal id)
//        {
//            var student = await _context.Students.FindAsync(id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            return student;
//        }

//        // PUT: api/Students/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutStudent(decimal id, Student student)
//        {
//            if (id != student.StudentId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(student).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!StudentExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Students
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Student>> PostStudent(Student student)
//        {
//            _context.Students.Add(student);
//            await _context.SaveChangesAsync();

//            //return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
//            return NoContent();
//        }

//        // DELETE: api/Students/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStudent(decimal id)
//        {
//            var student = await _context.Students.FindAsync(id);
//            var enrollment =  _context.Enrollments.Where(x=>(x.StudentId == id && x.Status==true)).ToList();
//            if (student == null)
//            {
//                return NotFound();
//            }
//            if(enrollment!=null)
//                foreach (var item in enrollment)
//                {
//                    item.Status = false;
//                }


//            student.Status = false;
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        [Route("Courses")]
//        // Get: api/Teachers/Homework
//        [HttpGet]

//        public async Task<ActionResult<IEnumerable<Enrollment>>> GetCoursesByStudent(decimal id)
//        {
//            return await _context.Enrollments.Where(x => (x.StudentId == id && x.Status == true)).ToListAsync();

//        }
//        private bool StudentExists(decimal id)
//        {
//            return _context.Students.Any(e => e.StudentId == id);
//        }
//    }
//}
