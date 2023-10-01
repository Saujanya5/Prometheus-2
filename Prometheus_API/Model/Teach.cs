using System;
using System.Collections.Generic;

#nullable disable

namespace Prometheus_API.Model
{
    public partial class Teach
    {
        public decimal TeacherId { get; set; }
        public decimal CourseId { get; set; }
        public bool? Status { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
