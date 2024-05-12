using System;
using System.Collections.Generic;

namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class PactProject
    {
        public int Id { get; set; }
        public int? IdPact { get; set; }
        public int? IdProject { get; set; }
    }
}
