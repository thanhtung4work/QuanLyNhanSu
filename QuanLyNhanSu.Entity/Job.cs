using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Entity
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
