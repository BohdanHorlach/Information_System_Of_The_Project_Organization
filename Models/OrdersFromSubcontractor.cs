using System;
using System.Collections.Generic;

namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class OrdersFromSubcontractor
    {
        public int Id { get; set; }
        public int? IdSubcontractors { get; set; }
        public int? IdProject { get; set; }
        public int? IdTypeOfOrderInSubcontractors { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public decimal? Cost { get; set; }
    }
}
