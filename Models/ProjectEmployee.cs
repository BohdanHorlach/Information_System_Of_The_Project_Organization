using System;
using System.Collections.Generic;

namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class ProjectEmployee
    {
        public int Id { get; set; }
        public int? IdProject { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdResponsibility { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}
