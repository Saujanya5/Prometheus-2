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
    [Route("Homework")]
    public class HomeworkViewModelsController : Controller
    {
        private readonly PROJECT_SPRINT1Context _context;

        public HomeworkViewModelsController()
        {

        }

        // GET: HomeworkViewModels
        // testing
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<HomeworkViewModel> homeworkList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Homework?code="+HttpContext.Session.GetString("Code"));
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
                    ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return View(homeworkList);
        }


        [Route("Details/{id}")]
        // GET: HomeworkViewModels/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Login", "TeacherHome");
            if (id == null)
            {
                return NotFound();
            }

            HomeworkViewModel homework = new HomeworkViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Homework/" + id+"?code="+HttpContext.Session.GetString("Code")))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        homework = JsonConvert.DeserializeObject<HomeworkViewModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            homework.Assignment = this.Assignment(id);

            return View(homework);
        }


        // GET: HomeworkViewModels/Create

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeworkViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Route("Create")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Deadline,ReqTime,LongDescription,Status")] HomeworkViewModel homeworkViewModel, [Bind("CourseId")] decimal courseId, [Bind("TeacherId")] decimal teacherId)
        {
            HomeworkViewModel homework = new HomeworkViewModel();
            try
            {

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(homeworkViewModel), Encoding.UTF8, "application/json");
               //https://localhost:44302/api/Homework?courseId=2009&teacherId=1009
                    using (var response = await httpClient.PostAsync("https://localhost:44302/api/Homework?courseId="+courseId+ "&teacherId="+teacherId+ "&code=" + HttpContext.Session.GetString("Code"), content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        homework = JsonConvert.DeserializeObject<HomeworkViewModel>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            return View(homework);
        }



        [Route("Edit/{id}")]
        // GET: HomeworkViewModels/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            HomeworkViewModel homework = new HomeworkViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Homework/" + id+ "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    homework = JsonConvert.DeserializeObject<HomeworkViewModel>(apiResponse);
                }
            }
            return View(homework);
        }

        // POST: HomeworkViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Description,Deadline,ReqTime,LongDescription,Status")] HomeworkViewModel homeworkViewModel)
        {
            HomeworkViewModel homework = new HomeworkViewModel();
            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(homeworkViewModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44302/api/Homework/" + id+ "?code=" + HttpContext.Session.GetString("Code"), content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    homework = JsonConvert.DeserializeObject<HomeworkViewModel>(apiResponse);
                }
            }
            return View(homework);
        }

        [Route("Delete/{id}")]
        // GET: HomeworkViewModels/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44302/api/Homework/" + id+ "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

        // POST: HomeworkViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var homeworkViewModel = await _context.HomeworkViewModel.FindAsync(id);
            _context.HomeworkViewModel.Remove(homeworkViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Route("Random2")]
        public IEnumerable<AssignmentViewModel> Assignment(decimal? id)
        {
            IEnumerable<AssignmentViewModel> courseList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Homework/Course?id=" + id+ "&code=" + HttpContext.Session.GetString("Code"));
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readResponse = result.Content.ReadAsAsync<IList<AssignmentViewModel>>();
                    readResponse.Wait();


                    courseList = readResponse.Result;
                }
                else
                {
                    courseList = Enumerable.Empty<AssignmentViewModel>();
                    //ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return courseList;
        }


        private bool HomeworkViewModelExists(decimal id)
        {
            return _context.HomeworkViewModel.Any(e => e.HomeWorkId == id);
        }
    }

}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//    public class HomeworkViewModelsController : Controller
//    {
//        private readonly PROJECT_SPRINT1Context _context;

//        public HomeworkViewModelsController(PROJECT_SPRINT1Context context)
//        {
//            _context = context;
//        }

//        // GET: HomeworkViewModels
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.HomeworkViewModel.ToListAsync());
//        }

//        // GET: HomeworkViewModels/Details/5
//        public async Task<IActionResult> Details(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var homeworkViewModel = await _context.HomeworkViewModel
//                .FirstOrDefaultAsync(m => m.HomeWorkId == id);
//            if (homeworkViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(homeworkViewModel);
//        }

//        // GET: HomeworkViewModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: HomeworkViewModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("HomeWorkId,Description,Deadline,ReqTime,LongDescription,Status")] HomeworkViewModel homeworkViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(homeworkViewModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(homeworkViewModel);
//        }

//        // GET: HomeworkViewModels/Edit/5
//        public async Task<IActionResult> Edit(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var homeworkViewModel = await _context.HomeworkViewModel.FindAsync(id);
//            if (homeworkViewModel == null)
//            {
//                return NotFound();
//            }
//            return View(homeworkViewModel);
//        }

//        // POST: HomeworkViewModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(decimal id, [Bind("HomeWorkId,Description,Deadline,ReqTime,LongDescription,Status")] HomeworkViewModel homeworkViewModel)
//        {
//            if (id != homeworkViewModel.HomeWorkId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(homeworkViewModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!HomeworkViewModelExists(homeworkViewModel.HomeWorkId))
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
//            return View(homeworkViewModel);
//        }

//        // GET: HomeworkViewModels/Delete/5
//        public async Task<IActionResult> Delete(decimal? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var homeworkViewModel = await _context.HomeworkViewModel
//                .FirstOrDefaultAsync(m => m.HomeWorkId == id);
//            if (homeworkViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(homeworkViewModel);
//        }

//        // POST: HomeworkViewModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(decimal id)
//        {
//            var homeworkViewModel = await _context.HomeworkViewModel.FindAsync(id);
//            _context.HomeworkViewModel.Remove(homeworkViewModel);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool HomeworkViewModelExists(decimal id)
//        {
//            return _context.HomeworkViewModel.Any(e => e.HomeWorkId == id);
//        }
//    }
//}
