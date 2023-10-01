using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prometheus_MVC.Models
{
    public class StudentViewModel
    {

        [Key]
        public decimal StudentId { get; set; }
        [Required]

        public string Fname { get; set; }
        [Required]

        public string Lname { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public DateTime Dob { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public long? MobileNo { get; set; }
        public bool? Status { get; set; }

        public string Code { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
        public IEnumerable<HomeworkViewModel> Homeworks { get; set; }
    }
}
