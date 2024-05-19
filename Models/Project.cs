namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string? NameProject { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
