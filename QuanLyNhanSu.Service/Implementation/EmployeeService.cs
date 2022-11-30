using QuanLyNhanSu.Entity;
using QuanLyNhanSu.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Service.NewFolder
{
    public class EmployeeService : IEmployee
    {
        private readonly QuanLyNhanSuDbContext _context;
        public EmployeeService(QuanLyNhanSuDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = GetById(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Where(employee => employee.Id == id).FirstOrDefault();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

    }
}
