using System;
using System.Collections.Generic;

#nullable disable

namespace Prometheus_MVC.Model
{
    public partial class Course
    {
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            Enrollments = new HashSet<Enrollment>();
            Teaches = new HashSet<Teach>();
        }

        public decimal CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}
