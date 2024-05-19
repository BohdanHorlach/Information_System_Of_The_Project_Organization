namespace Information_System_Of_The_Project_Organization.Models
{
    public class CurrentEquipmentInvolved
    {
        public int EquipmentId { get; set; }
        public string? EquipmentName { get; set; }
        public string? Destination { get; set; }
        public int EquipmentDepartmentId { get; set; }
        public int? IdDepartaments { get; set; }
        public int? IdEquipment { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}
