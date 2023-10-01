using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prometheus_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus_MVC.Controllers
{
    public class TeacherHomeController : Controller
    {
        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Login", "TeacherHome");
            return View();
        }

        [HttpGet]
        public IActionResult Courses()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Index", "TeacherHome");          
            TeacherViewModelsController teacherControl = new TeacherViewModelsController();
            decimal id = Convert.ToDecimal(HttpContext.Session.GetString("Id"));
            var code = HttpContext.Session.GetString("Code");
            var courseList = teacherControl.Courses(id, HttpContext.Session.GetString("Code"));
            
            return View(courseList);
        }


        [HttpGet]
        public IActionResult AddHomeWork()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Index", "TeacherHome");
            TeacherViewModelsController teacherControl = new TeacherViewModelsController();
            decimal id = Convert.ToDecimal(HttpContext.Session.GetString("Id"));
            var code = HttpContext.Session.GetString("Code");
            var courseList = teacherControl.Courses(id, HttpContext.Session.GetString("Code"));
            ViewData["Courses"] = courseList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHomeWork([Bind("Description,Deadline,ReqTime,LongDescription")] HomeworkViewModel homework,[Bind("CourseId")]decimal courseId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(homework), Encoding.UTF8, "application/json");
                    //https://localhost:44302/api/Homework?courseId=2009&teacherId=1009
                    using (var response = await httpClient.PostAsync("https://localhost:44302/api/Homework?courseId=" + courseId + "&teacherId=" + HttpContext.Session.GetString("Id")+"&code="+ HttpContext.Session.GetString("Code"), content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            homework = JsonConvert.DeserializeObject<HomeworkViewModel>(apiResponse);
                            ViewBag.Status = "Successfull";
                        }
                        else
                        {
                            ViewBag.Status = "unsuccessfull";
                        }


                    }
                }
            }
            catch(Exception e)
            {
                ViewBag.Status = "unsuccessfull";
            }
            return View();
        }

        [HttpGet]
        public IActionResult AssignCourse()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Index", "TeacherHome");
            IEnumerable<TeacherViewModel> teacherList = null;
            CourseViewModelsController courseControl = new CourseViewModelsController();
            var allCourses = courseControl.AllCourses(HttpContext.Session.GetString("Code"));
            ViewData["Courses"] = allCourses;
            var httpClient = new HttpClient();         
            
            // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
            var response = httpClient.GetAsync("https://localhost:44302/api/Teachers" + "?code=" + HttpContext.Session.GetString("Code"));
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readResponse = result.Content.ReadAsAsync<IList<TeacherViewModel>>();
                    readResponse.Wait();


                    teacherList = readResponse.Result;
                    ViewData["teachers"] = teacherList;
                }

            
                return View();
        }
        [HttpPost]
        public IActionResult AssignCourse([Bind("CourseId","TeacherId")] TeachesViewModel teach)
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Index", "TeacherHome");
            IEnumerable<TeacherViewModel> teacherList = null;            
            var httpClient = new HttpClient();
            // client.BaseAddress = new Uri("https://localhost:44344/api/%22);
            StringContent content = new StringContent(JsonConvert.SerializeObject(teach), Encoding.UTF8, "application/json");
            try
            {
                var response = httpClient.PostAsync("https://localhost:44302/api/Teachers/Assign" + "?code=" + HttpContext.Session.GetString("Code"), content);
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Status = "Success";
                }
                else if(result.StatusCode == HttpStatusCode.InternalServerError)
                {
                    ViewBag.Status = "Unsuccessful";
                    ViewBag.Error = "SQL";
                }
                else
                {
                    ViewBag.Status = "Unsuccessful";
                }
            }
            catch
            {
                ViewBag.Status = "Unsuccessful";
                ViewBag.Error = "SQL";
            }

            return View();
        }
        public IActionResult Homeworks()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Index", "TeacherHome");
            TeacherViewModelsController teacherControl = new TeacherViewModelsController();
            decimal id = Convert.ToDecimal(HttpContext.Session.GetString("Id"));
            var code = HttpContext.Session.GetString("Code");
            var homeworks = teacherControl.Homeworks(id, HttpContext.Session.GetString("Code"));

            return View(homeworks);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Id") != null)
                return RedirectToAction("Index", "TeacherHome");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind("TeacherId", "Password")] TeacherViewModel teacher)
        {
            using (HttpClient client = new HttpClient())
            {


                var responseTask = client.GetAsync("https://localhost:44302/api/Teachers/Login?id=" + teacher.TeacherId + "&password=" + teacher.Password);

                responseTask.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;


                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TeacherViewModel>();
                    readTask.Wait();
                    teacher = readTask.Result;
                    HttpContext.Session.SetString("Id", teacher.TeacherId.ToString());
                    HttpContext.Session.SetString("Name", teacher.Fname);
                    if(Convert.ToBoolean(teacher.IsAdmin))
                        HttpContext.Session.SetString("Role", "Admin");
                    else
                        HttpContext.Session.SetString("Role", "Teacher");
                    HttpContext.Session.SetString("Code", teacher.Address);
                    return RedirectToAction("Index", "TeacherHome");
                }
                else
                {
                    ViewBag.Status = "Unsuccessfull";
                }

            }
            HttpContext.Session.Clear();

            ModelState.AddModelError(string.Empty, "Please Check your Email or Password.");


            return View("Login", teacher);

        }

        public IActionResult Logout()
        {

            HttpClient client = new HttpClient();
            client.GetAsync("https://localhost:44302/api/Session/Logout?code=" + HttpContext.Session.GetString("code"));
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
