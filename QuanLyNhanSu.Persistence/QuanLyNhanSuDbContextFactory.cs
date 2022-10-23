using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Persistence
{
    public class QuanLyNhanSuDbContextFactory : IDesignTimeDbContextFactory<QuanLyNhanSuDbContext>
    {
        public QuanLyNhanSuDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<QuanLyNhanSuDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuanLyNhanSu;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new QuanLyNhanSuDbContext(optionBuilder.Options);
        }
    }
}
