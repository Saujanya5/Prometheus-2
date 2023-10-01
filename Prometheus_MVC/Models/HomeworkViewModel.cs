using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prometheus_MVC.Models
{
    public class HomeworkViewModel
    {
        [Required]
        [Key]

        public decimal HomeWorkId { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public DateTime Deadline { get; set; }
        [Required]

        public int ReqTime { get; set; }
        [Required]

        public string LongDescription { get; set; }

        public bool Status { get; set; }
        public IEnumerable<AssignmentViewModel> Assignment { get; set; }

    }
}
