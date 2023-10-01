using System;
using System.Collections.Generic;

#nullable disable

namespace Prometheus_API.Model
{
    public partial class Homework
    {
        public Homework()
        {
            Assignments = new HashSet<Assignment>();
        }

        public decimal HomeWorkId { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int? ReqTime { get; set; }
        public string LongDescription { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
