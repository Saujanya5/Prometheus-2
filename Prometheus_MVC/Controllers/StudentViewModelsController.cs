using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Prometheus_MVC.Model;
using Prometheus_MVC.Models;

namespace Prometheus_MVC.Controllers
{
    [Route("Student")]
    public class StudentViewModelsController : Controller
    {
        private readonly PROJECT_SPRINT1Context _context;

        public StudentViewModelsController()
        {
            
        }

        // GET: StudentViewModels
        public async Task<IActionResult> Index()
        {
            IEnumerable<StudentViewModel> studentList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Students" + "?code=" + HttpContext.Session.GetString("Code"));
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readResponse = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                    readResponse.Wait();


                    studentList = readResponse.Result;
                }
                else
                {
                    studentList = Enumerable.Empty<StudentViewModel>();
                    ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }
            return View(studentList);
        }

        [Route("Details/{id}")]
        // GET: StudentViewModels/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentViewModel student = new StudentViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Students/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            student.StudentId = Convert.ToDecimal(id);
            student.Courses = this.Courses(id,HttpContext.Session.GetString("Code"));
            return View(student);
        }

        // GET: StudentViewModels/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fname,Lname,Address,Dob,City,Password,MobileNo")] StudentViewModel studentViewModel)
        {
            StudentViewModel student = new StudentViewModel();
            try
            {

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(studentViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44302/api/Students" + "?code=" + HttpContext.Session.GetString("Code"), content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse);
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.Status = "Success";
                        }
                        else
                            ViewBag.Status = "Unsuccessfull";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                ViewBag.Status = "Unsuccessfull";
            }
            return View(student);
        }


        [Route("Edit/{id}")]
        // GET: StudentViewModels/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentViewModel student = new StudentViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Students/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse);
                }
            }
            return View(student);
        }

        // POST: StudentViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Fname,Lname,Address,Dob,City,Password,MobileNo")] StudentViewModel studentViewModel)
        {

            StudentViewModel student = new StudentViewModel();
            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(studentViewModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44302/api/Students/" + id + "?code=" + HttpContext.Session.GetString("Code"), content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        student = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse);
                        ViewBag.Status = "Success";
                    }
                    else

                        ViewBag.Status = "Unsuccessfull";
                }
            }
            return View(student);
        }

        // GET: StudentViewModels/Delete/5
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44302/api/Students/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

        // POST: StudentViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var studentViewModel = await _context.StudentViewModel.FindAsync(id);
            _context.StudentViewModel.Remove(studentViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Route("Random2")]
        public IEnumerable<CourseViewModel> Courses(decimal? id,string code)
        {

            IEnumerable<CourseViewModel> courseList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Students/Courses?id=" + id+"&code="+code);
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readResponse = result.Content.ReadAsAsync<IList<CourseViewModel>>();
                    readResponse.Wait();


                    courseList = readResponse.Result;
                }
                else
                {
                    courseList = Enumerable.Empty<CourseViewModel>();
                    //ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return courseList;
        }

        private bool StudentViewModelExists(decimal id)
        {
            return _context.StudentViewModel.Any(e => e.StudentId == id);
        }
    }
}
//    public class StudentViewModelsController : Controller
//    {
//        private readonly PROJECT_SPRINT1Context _context;

//        public StudentViewModelsController(PROJECT_SPRINT1Context context)
//        {
//            _context = context;
//        }

//        // GET: StudentViewModels
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.StudentViewModel.ToListAsync());
//        }

//        // GET: StudentViewModels/Details/5
//        public async Task<IActionResult> Details(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var studentViewModel = await _context.StudentViewModel
//                .FirstOrDefaultAsync(m => m.StudentId == id);
//            if (studentViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(studentViewModel);
//        }

//        // GET: StudentViewModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: StudentViewModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("StudentId,Fname,Lname,Address,Dob,City,Password,MobileNo,Status")] StudentViewModel studentViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(studentViewModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(studentViewModel);
//        }

//        // GET: StudentViewModels/Edit/5
//        public async Task<IActionResult> Edit(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var studentViewModel = await _context.StudentViewModel.FindAsync(id);
//            if (studentViewModel == null)
//            {
//                return NotFound();
//            }
//            return View(studentViewModel);
//        }

//        // POST: StudentViewModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(decimal id, [Bind("StudentId,Fname,Lname,Address,Dob,City,Password,MobileNo,Status")] StudentViewModel studentViewModel)
//        {
//            if (id != studentViewModel.StudentId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(studentViewModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentViewModelExists(studentViewModel.StudentId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(studentViewModel);
//        }

//        // GET: StudentViewModels/Delete/5
//        public async Task<IActionResult> Delete(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var studentViewModel = await _context.StudentViewModel
//                .FirstOrDefaultAsync(m => m.StudentId == id);
//            if (studentViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(studentViewModel);
//        }

//        // POST: StudentViewModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(decimal id)
//        {
//            var studentViewModel = await _context.StudentViewModel.FindAsync(id);
//            _context.StudentViewModel.Remove(studentViewModel);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentViewModelExists(decimal id)
//        {
//            return _context.StudentViewModel.Any(e => e.StudentId == id);
//        }
//    }
//}
