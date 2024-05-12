using System;
using System.Collections.Generic;

namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class DepartmentsLeader
    {
        public int Id { get; set; }
        public int? IdDepartaments { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? DismissalDate { get; set; }
    }
}
