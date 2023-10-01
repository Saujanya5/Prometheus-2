using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prometheus_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Session;
using System.Net;
using System.Text;

namespace Prometheus_MVC.Controllers
{
    public class StudentHomeController : Controller
    {
        IEnumerable<CourseViewModel> availableCourses; 
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Login", "StudentHome");
            return View();

        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Id") != null)
                return RedirectToAction("Index", "StudentHome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("StudentId", "Password")] StudentViewModel student)
        {
            using (HttpClient client = new HttpClient())
            {


                var responseTask = client.GetAsync("https://localhost:44302/api/Students/Login?id=" + student.StudentId + "&password=" + student.Password);
                
                responseTask.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;


                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StudentViewModel>();
                    readTask.Wait();
                    student = readTask.Result;
                    HttpContext.Session.SetString("Id", student.StudentId.ToString());
                    HttpContext.Session.SetString("Name", student.Fname);
                    HttpContext.Session.SetString("Role", "Student");
                    HttpContext.Session.SetString("Code",student.Address);
                    return RedirectToAction("Index", "StudentHome");
                }
                else
                {
                    ViewBag.Status = "Unsuccessfull";
                }

            }
            HttpContext.Session.Clear();

            ModelState.AddModelError(string.Empty, "Please Check your Email or Password.");


            return View("Login", student);

        }

        [HttpGet]
        public IActionResult Courses()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Login", "StudentHome");
            StudentViewModelsController studentControl = new StudentViewModelsController();
            decimal id = Convert.ToDecimal(HttpContext.Session.GetString("Id"));
            var code = HttpContext.Session.GetString("Code");
            var courseList = studentControl.Courses(id, HttpContext.Session.GetString("Code"));

            return View(courseList);
        }
        [HttpGet]
        public IActionResult ApplyCourse()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Login", "StudentHome");
            StudentViewModelsController studentControl = new StudentViewModelsController();
            decimal id = Convert.ToDecimal(HttpContext.Session.GetString("Id"));
            var courseList = studentControl.Courses(id, HttpContext.Session.GetString("Code"));
            CourseViewModelsController courseControl = new CourseViewModelsController();
            var allCourses = courseControl.AllCourses(HttpContext.Session.GetString("Code"));
            List<CourseViewModel> availableCourses =new List<CourseViewModel>();
            foreach (var item in allCourses)
            {
                bool found = false;
                foreach (var item2 in courseList)
                {
                    if (item2.CourseId == item.CourseId)
                    {
                        found = true;
                        break;
                    }
                    
                }
                if (!found)
                    availableCourses.Add(item);
            }
            return View(availableCourses);
        }
        [HttpPost]
        public async Task<IActionResult> ApplyCourse([Bind("CourseId")] EnrollmentViewModel enrollment)
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Login", "StudentHome");
            
            enrollment.StudentId = Convert.ToDecimal(HttpContext.Session.GetString("Id"));
            enrollment.Status = true;
            try
            {

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(enrollment), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44302/api/Students/Enroll"+ "?code=" + HttpContext.Session.GetString("Code"), content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            enrollment = JsonConvert.DeserializeObject<EnrollmentViewModel>(apiResponse);
                            ViewBag.Status = "Successfull";
                        }
                        else
                            ViewBag.Status = "Unsuccessfull";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Status = "Unsuccessfull";
            }
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Homework()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction("Login", "StudentHome");
            List<HomeworkViewModel> homeworks =null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44302/api/Students/Homework?id=" + HttpContext.Session.GetString("Id") + "&code=" + HttpContext.Session.GetString("Code")))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        homeworks = JsonConvert.DeserializeObject<IEnumerable<HomeworkViewModel>>(apiResponse).ToList() ;
                        homeworks.Sort((x, y) => x.Deadline.CompareTo(y.Deadline));
                        var time = homeworks[0].Deadline - DateTime.Today;
                        float days = time.Days;
                        string plan;
                        if (days > 0.0f)
                        {
                            float hoursPerDay = (float)homeworks[0].ReqTime / days;
                            if (hoursPerDay > 0.5f)
                                plan = $"Devote {hoursPerDay:00.00} hour/s per day to finish on time";
                            else
                                plan = "You can relax as the closest deadline is very far";
                        }

                        else
                            plan = "You were unable to submit on time, do it ASAP";
                        ViewBag.Plan = plan;
                    }
                    else
                    {
                        homeworks.Add(new HomeworkViewModel());
                        ViewBag.Status = "Error";
                    }
                }
            }
            IEnumerable<HomeworkViewModel> homeworkList = homeworks; 
            return View(homeworkList);
        }
        //public IActionResult CheckSession()
        //{
        //    if (HttpContext.Session.GetString("Id") == null)
        //        return RedirectToAction("Login", "StudentHome");
        //    else
        //        return NoContent();
        //}
        public IActionResult Logout()
        {
            
            HttpClient client = new HttpClient();
            client.GetAsync("https://localhost:44302/api/Session/Logout?code="+ HttpContext.Session.GetString("code"));
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}
