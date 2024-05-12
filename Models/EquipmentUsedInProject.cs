using System;
using System.Collections.Generic;

namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class EquipmentUsedInProject
    {
        public int Id { get; set; }
        public int? IdEquipment { get; set; }
        public int? IdProjects { get; set; }
        public int? IdTypeOfWork { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}
