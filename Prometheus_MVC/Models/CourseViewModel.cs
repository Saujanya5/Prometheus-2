using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prometheus_MVC.Models
{
    public class CourseViewModel
    {
        [Required]
        [Key]
        public decimal CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public IEnumerable<HomeworkViewModel> Homework { get; set; }
        public IEnumerable<TeacherViewModel> Teacher { get; set; }
        public IEnumerable<StudentViewModel> Student { get; set; }

    }
}
