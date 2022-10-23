using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Persistence
{
    public class QuanLyNhanSuDbContext : DbContext
    {
        public QuanLyNhanSuDbContext(DbContextOptions options) : base(options)
        {
            // do something
            // Microsoft.EntityFrameworkCore.SqlServer
            // Microsoft.EntityFrameworkCore.Tools
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProjectParticipant>()
                .HasOne<Project>(pp => pp.Project)
                .WithMany(p => p.ProjectParticipants)
                .HasForeignKey(pp => pp.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectParticipant>()
                .HasOne<Employee>(pp => pp.Employee)
                .WithMany(e => e.ProjectParticipants)
                .HasForeignKey(pp => pp.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DepartmentManager>()
                .HasOne(dm => dm.Department)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DepartmentManager>()
                .HasOne(dm => dm.Employee)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Location)
                .WithMany(l => l.Projects)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Relative> Relatives { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectParticipant> ProjectParticipants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DepartmentManager> DepartmentManagers { get; set; }
    }
}
