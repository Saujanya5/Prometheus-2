using System;
using System.Collections.Generic;

#nullable disable

namespace Prometheus_API.Model
{
    public partial class Enrollment
    {
        public decimal CourseId { get; set; }
        public decimal StudentId { get; set; }
        public bool? Status { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
