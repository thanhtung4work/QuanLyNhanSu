namespace QuanLyNhanSu.Entity
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int LocationId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }

        public Location Location { get; set; }
        public ICollection<ProjectParticipant> ProjectParticipants { get; set; }
    }
}