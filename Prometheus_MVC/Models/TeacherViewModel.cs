using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prometheus_MVC.Models
{

    public class TeacherViewModel
    {
        [Key]
        
        public decimal TeacherId { get; set; }

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


        public bool? IsAdmin { get; set; }
        
        public bool? Status { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }
        public IEnumerable<HomeworkViewModel> Homework { get; set; }

    }
}
