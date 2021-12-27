//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using TicketSystem.Models;

//namespace TicketSystem.ModelValidations
//{
//    public class Ticket_EnsureDueDateForTicketOwner : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var ticket = validationContext.ObjectInstance as Ticket;

//            if (ticket !=null && !string.IsNullOrEmpty(ticket.Owner))
//            {
//                if (!ticket.DueDate.HasValue)
//                {
//                    return new ValidationResult("Due date is required when we have user");
//                }
//            }
//            return ValidationResult.Success;
//        }
//    }
//}
