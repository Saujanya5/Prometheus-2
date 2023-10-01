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

    [Route("Courses")]
    public class CourseViewModelsController : Controller
    {

        private readonly PROJECT_SPRINT1Context _context;

        public CourseViewModelsController()
        {

        }

        //[Route("Courses")]
        public IActionResult Index()
        {
            IEnumerable<CourseViewModel> courseList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Courses" + "?code=" + HttpContext.Session.GetString("Code"));
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
                    ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return View(courseList);
        }

        [Route("Details/{id}")]
        //GET: CourseViewModels/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CourseViewModel course = new CourseViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Courses/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonConvert.DeserializeObject<CourseViewModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            course.Homework = this.Homeworks(id);
            course.Teacher = this.Teachers(id);
            course.Student = this.Students(id);
            return View(course);
        }

        // GET: CourseViewModels/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CourseName,StartDate,EndDate,Status")] CourseViewModel courseViewModel)
        {
            CourseViewModel course = new CourseViewModel();
            try
            {

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(courseViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44302/api/Courses" + "?code=" + HttpContext.Session.GetString("Code"), content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            course = JsonConvert.DeserializeObject<CourseViewModel>(apiResponse);
                            ViewBag.Status = "Success";
                        }
                        else
                        {
                            ViewBag.Status = "Unsuccessfull";

                        }
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                ViewBag.Status = "Unsuccessfull";

            }
            return View(course);
        }


        [Route("Edit/{id}")]
        // GET: TeacherViewModels/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            CourseViewModel course = new CourseViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Courses/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<CourseViewModel>(apiResponse);
                }
            }
            return View(course);
        }


        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CourseId,CourseName,StartDate,EndDate,Status")] CourseViewModel courseViewModel)
        {

            CourseViewModel course = new CourseViewModel();
            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(courseViewModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44302/api/Courses/" + id + "?code=" + HttpContext.Session.GetString("Code"), content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        course = JsonConvert.DeserializeObject<CourseViewModel>(apiResponse);
                        ViewBag.Status = "Success";

                    }
                    else
                    {
                        ViewBag.Status = "Unsuccessfull";

                    }
                }
            }
            return View(course);

        }

        //// GET: TeacherViewModels/Delete/5
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44302/api/Courses/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }


        // POST: TeacherViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var courseViewModel = await _context.CourseViewModel.FindAsync(id);
            _context.CourseViewModel.Remove(courseViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Route("Random1")]
        public IEnumerable<HomeworkViewModel> Homeworks(decimal? id)
        {
            IEnumerable<HomeworkViewModel> homeworkList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Courses/Homework?id=" + id + "&code=" + HttpContext.Session.GetString("Code"));
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readResponse = result.Content.ReadAsAsync<IList<HomeworkViewModel>>();
                    readResponse.Wait();


                    homeworkList = readResponse.Result;
                }
                else
                {
                    homeworkList = Enumerable.Empty<HomeworkViewModel>();
                    //ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return homeworkList;
        }


        [Route("Random2")]
        public IEnumerable<TeacherViewModel> Teachers(decimal? id)
        {
            IEnumerable<TeacherViewModel> teacherList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Courses/Teacher?id=" + id + "&code=" + HttpContext.Session.GetString("Code"));
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readResponse = result.Content.ReadAsAsync<IList<TeacherViewModel>>();

                    readResponse.Wait();


                    teacherList = readResponse.Result;
                }
                else
                {
                    teacherList = Enumerable.Empty<TeacherViewModel>();
                    //ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return teacherList;
        }

        [Route("Random3")]
        public IEnumerable<StudentViewModel> Students(decimal? id)
        {
            IEnumerable<StudentViewModel> studentList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Courses/Student?id=" + id + "&code=" + HttpContext.Session.GetString("Code"));
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
                    //ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return studentList;
        }
        [Route("Rndom")]
        public IEnumerable<CourseViewModel> AllCourses(string code)
        {
            IEnumerable<CourseViewModel> courseList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Courses" + "?code=" +code);
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
                    ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return courseList;
        }


    }



}


//////////////////////////////////////////////////////////////////////////////////////////////////
//    public class CourseViewModelsController : Controller
//    {
//        private readonly PROJECT_SPRINT1Context _context;

//        public CourseViewModelsController(PROJECT_SPRINT1Context context)
//        {
//            _context = context;
//        }

//        // GET: CourseViewModels
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.CourseViewModel.ToListAsync());
//        }

//        // GET: CourseViewModels/Details/5
//        public async Task<IActionResult> Details(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var courseViewModel = await _context.CourseViewModel
//                .FirstOrDefaultAsync(m => m.CourseId == id);
//            if (courseViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(courseViewModel);
//        }

//        // GET: CourseViewModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: CourseViewModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("CourseId,CourseName,StartDate,EndDate,Status")] CourseViewModel courseViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(courseViewModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(courseViewModel);
//        }

//        // GET: CourseViewModels/Edit/5
//        public async Task<IActionResult> Edit(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var courseViewModel = await _context.CourseViewModel.FindAsync(id);
//            if (courseViewModel == null)
//            {
//                return NotFound();
//            }
//            return View(courseViewModel);
//        }

//        // POST: CourseViewModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(decimal id, [Bind("CourseId,CourseName,StartDate,EndDate,Status")] CourseViewModel courseViewModel)
//        {
//            if (id != courseViewModel.CourseId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(courseViewModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CourseViewModelExists(courseViewModel.CourseId))
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
//            return View(courseViewModel);
//        }

//        // GET: CourseViewModels/Delete/5
//        public async Task<IActionResult> Delete(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var courseViewModel = await _context.CourseViewModel
//                .FirstOrDefaultAsync(m => m.CourseId == id);
//            if (courseViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(courseViewModel);
//        }

//        // POST: CourseViewModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(decimal id)
//        {
//            var courseViewModel = await _context.CourseViewModel.FindAsync(id);
//            _context.CourseViewModel.Remove(courseViewModel);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CourseViewModelExists(decimal id)
//        {
//            return _context.CourseViewModel.Any(e => e.CourseId == id);
//        }
//    }
//}
