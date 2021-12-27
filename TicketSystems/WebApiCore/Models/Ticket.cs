//using System;
//using System.ComponentModel.DataAnnotations;
//using TicketSystem.ModelValidations;

//namespace TicketSystem.Models
//{
//    public class Ticket
//    {
//        public int? TicketId { get; set; }

//        [Required]
//        public int ProjectId { get; set; }

//        [Required]
//        public string Title { get; set; }

//        public string Description { get; set; }
//        public string Owner { get; set; }

//        [Ticket_EnsureDueDateForTicketOwner]
//        [DueDate_EnsureFutureDate]
//        public DateTime? DueDate { get; set; }

//        public DateTime? EnteredDate { get; set; }

//    }
//}
