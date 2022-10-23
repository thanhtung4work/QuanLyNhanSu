namespace QuanLyNhanSu.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public decimal Salary { get; set; }
        public int JobId { get; set; }
        public int DepartmentId { get; set; }

        public Job Job { get; set; }
        public Department Department { get; set; }
        public ICollection<ProjectParticipant> ProjectParticipants { get; set; }
        public Relative Relative { get; set; }

    }
}