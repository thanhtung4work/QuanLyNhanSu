using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanSu.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}