using System;
using System.Collections.Generic;

#nullable disable

namespace Prometheus_MVC.Model
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public decimal StudentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public decimal? MobileNo { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
