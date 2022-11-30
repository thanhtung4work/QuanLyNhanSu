using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Service
{
    public interface IEmployee
    {
        Task CreateAsync(Employee employee);
        Employee GetById(int id);
        Task UpdateAsync(int id);
        Task DeleteAsync(int id);
        
        IEnumerable<Employee> GetAll();
    }
}
