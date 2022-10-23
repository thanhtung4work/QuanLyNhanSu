using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Entity
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Region { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
