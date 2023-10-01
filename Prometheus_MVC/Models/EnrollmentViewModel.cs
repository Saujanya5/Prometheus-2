using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prometheus_MVC.Models
{
    public class EnrollmentViewModel
    {
        public decimal CourseId { get; set; }
        public decimal StudentId { get; set; }
        public bool? Status { get; set; }
    }
}
