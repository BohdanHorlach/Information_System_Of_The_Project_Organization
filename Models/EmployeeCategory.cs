using System;
using System.Collections.Generic;

namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class EmployeeCategory
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? AssignmentDate { get; set; }
    }
}
