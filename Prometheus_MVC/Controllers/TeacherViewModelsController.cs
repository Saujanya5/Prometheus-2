using System;
using System.Collections;
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

    [Route("Teachers")]
    public class TeacherViewModelsController : Controller
    {
        private readonly PROJECT_SPRINT1Context _context;
 
        public TeacherViewModelsController()
        {
            
        }

        // GET: TeacherViewModels
        public async Task<IActionResult> Index()
        {
            IEnumerable<TeacherViewModel> teacherList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Teachers" + "?code=" + HttpContext.Session.GetString("Code"));
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
                    ModelState.AddModelError(string.Empty, "An Error Occured,Contact Admin ");
                }

            }

            return View(teacherList);
        }

      ///  public ViewResult Details() => View();

        [Route("Details/{id}")]
        //GET: TeacherViewModels/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            TeacherViewModel teacher = new TeacherViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Teachers/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        teacher = JsonConvert.DeserializeObject<TeacherViewModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
           
            teacher.Courses = this.Courses(id,HttpContext.Session.GetString("Code"));
            teacher.Homework = this.Homeworks(id,HttpContext.Session.GetString("Code"));
            return View(teacher);
        }

        // GET: TeacherViewModels/Create

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fname,Lname,Address,Dob,City,Password,MobileNo,IsAdmin,Status")] TeacherViewModel teacherViewModel)
        {
            TeacherViewModel teacher = new TeacherViewModel();
            try
            {
                
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(teacherViewModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44302/api/Teachers" + "?code=" + HttpContext.Session.GetString("Code"), content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            teacher = JsonConvert.DeserializeObject<TeacherViewModel>(apiResponse);
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
            return View(teacher);
        }


        [Route("Edit/{id}")]
        // GET: TeacherViewModels/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            TeacherViewModel teacher = new TeacherViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Teachers/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teacher = JsonConvert.DeserializeObject<TeacherViewModel>(apiResponse);
                }
            }
            return View(teacher);



            /////////////////
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var teacherViewModel = await _context.TeacherViewModel.FindAsync(id);
            //if (teacherViewModel == null)
            //{
            //    return NotFound();
            //}
            //return View(teacherViewModel);
        }

        // POST: TeacherViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Fname,Lname,Address,Dob,City,Password,MobileNo,IsAdmin,Status")] TeacherViewModel teacherViewModel)
        {

            TeacherViewModel teacher = new TeacherViewModel();
            using (var httpClient = new HttpClient())
            {
                //var content = new MultipartFormDataContent();
                ////content.Add(new StringContent(id.ToString()), "TeacherId");
                //content.Add(new StringContent(teacherViewModel.Fname), "Fname");
                //content.Add(new StringContent(teacherViewModel.Lname), "Lname");
                //content.Add(new StringContent(teacherViewModel.Address), "Address");
                //content.Add(new StringContent(teacherViewModel.Dob.ToString()), "Dob");
                //content.Add(new StringContent(teacherViewModel.City), "City");
                //content.Add(new StringContent(teacherViewModel.Password), "Password");
                //content.Add(new StringContent(teacherViewModel.MobileNo.ToString()), "MobileNo");
                //content.Add(new StringContent(teacherViewModel.IsAdmin.ToString()), "IsAdmin");
                //content.Add(new StringContent(teacherViewModel.Status.ToString()), "Status");
                StringContent content = new StringContent(JsonConvert.SerializeObject(teacherViewModel), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44302/api/Teachers/"+id + "?code=" + HttpContext.Session.GetString("Code"), content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        teacher = JsonConvert.DeserializeObject<TeacherViewModel>(apiResponse);
                        ViewBag.Status = "Success";
                    }
                    else
                   
                    ViewBag.Status = "Unsuccessfull";
                }
            }
            return View(teacher);


            ////
            //if (id != teacherViewModel.TeacherId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(teacherViewModel);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!TeacherViewModelExists(teacherViewModel.TeacherId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(teacherViewModel);
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
                using (var response = await httpClient.DeleteAsync("https://localhost:44302/api/Teachers/" + id + "?code=" + HttpContext.Session.GetString("Code")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");

            //var teacherViewModel = await _context.TeacherViewModel
            //    .FirstOrDefaultAsync(m => m.TeacherId == id);
            //if (teacherViewModel == null)
            //{
            //    return NotFound();
            //}

            //return View(teacherViewModel);
        }

        // POST: TeacherViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var teacherViewModel = await _context.TeacherViewModel.FindAsync(id);
            _context.TeacherViewModel.Remove(teacherViewModel);
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
                var response = client.GetAsync("https://localhost:44302/api/Teachers/Courses?id=" + id + "&code=" + code);
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

        [Route("Random")]
        public IEnumerable<HomeworkViewModel> Homeworks(decimal? id,string code)
        {
            IEnumerable<HomeworkViewModel> homeworkList = null;
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
                var response = client.GetAsync("https://localhost:44302/api/Teachers/Homework?id=" + id + "&code=" + code);
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


        //private bool TeacherViewModelExists(decimal id)
        //{
        //    return _context.TeacherViewModel.Any(e => e.TeacherId == id);
        //}
    }
}
