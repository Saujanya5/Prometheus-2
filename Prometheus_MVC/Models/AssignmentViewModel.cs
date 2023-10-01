using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prometheus_MVC.Models
{
    public class AssignmentViewModel
    {
        [Key]
        public decimal HomeWorkId { get; set; }
        public decimal TeacherId { get; set; }
        public decimal CourseId { get; set; }
        public bool? Status { get; set; }
    }
}
