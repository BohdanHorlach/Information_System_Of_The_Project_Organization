using System;
using System.Collections.Generic;

namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class Pact
    {
        public int Id { get; set; }
        public string? PactName { get; set; }
        public string? FullNameCustomer { get; set; }
        public string? EmailCustomer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
