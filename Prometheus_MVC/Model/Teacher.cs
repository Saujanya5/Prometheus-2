using System;
using System.Collections.Generic;

#nullable disable

namespace Prometheus_MVC.Model
{
    public partial class Teacher
    {
        public Teacher()
        {
            Teaches = new HashSet<Teach>();
        }

        public decimal TeacherId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public decimal? MobileNo { get; set; }
        public bool IsAdmin { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Teach> Teaches { get; set; }
    }
}
