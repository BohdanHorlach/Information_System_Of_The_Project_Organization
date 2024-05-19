namespace Information_System_Of_The_Project_Organization.Models
{
    public class UsedEquipmentFromPact
    {
        public int Id { get; set; }
        public string? EquipmentName { get; set; }
        public string? Destination { get; set; }
        public string? PactName { get; set; }
        public string? NameProject { get; set; }
        public string? TypeOfWork { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}
