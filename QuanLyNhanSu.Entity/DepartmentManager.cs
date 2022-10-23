using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Entity
{
    public class DepartmentManager
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PromotionDate { get; set; }

        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}
