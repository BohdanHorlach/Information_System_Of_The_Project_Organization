namespace Information_System_Of_The_Project_Organization.Models
{
    public class EmployeesInfoToProjectsActivities
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Education { get; set; }
        public string? CategoryName { get; set; }
        public string? NameProject { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}
